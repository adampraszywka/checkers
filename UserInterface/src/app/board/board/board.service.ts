import {inject, Injectable, signal} from "@angular/core";
import {Observable, Subject} from "rxjs";
import {BoardClientService} from "../services/board-client.service";
import {HttpErrorResponse} from "@angular/common/http";
import {Square} from "../../shared/dto/square.interface";
import {PossibleMove} from "../../shared/dto/possiblemove.interface";
import {Board} from "../../shared/dto/board.interface";
import {Move} from "../../shared/dto/move.interface";
import {PlayerIdProvider} from "../../shared/authorization/playerid-provider.service";
import {Color} from "../../shared/dto/piece.interface";
import {BoardData} from "../dto/board-data.interface";

@Injectable()
export class BoardService {
  clientService = inject(BoardClientService);
  idProvider = inject(PlayerIdProvider);

  selectedSquare = signal<Square|null>(null)
  possibleMoves = signal<PossibleMove[]>([] as PossibleMove[]);
  board = signal<BoardData|null>(null);

  private readonly errorNotificationSource: Subject<string> = new Subject<string>();
  public readonly errorNotificationRequested$: Observable<string> = this.errorNotificationSource.asObservable();

  public initialize(boardId: string): void {
    this.clientService.dashboardUpdatedRequested.subscribe(x => this.board.set(this.toBoardData(x)));
    this.clientService.initialize(boardId);
  }

  private toBoardData(board: Board): BoardData {
    const playerColor = this.extractPlayerColor(board);
    return {board: board, playerColor: playerColor ?? Color.White};
  }

  private extractPlayerColor(board: Board): Color|null {
    const playerId = this.idProvider.get();
    const participant = board.participants.find(x => x.id === playerId);

    if (participant === undefined) {
      return Color.White;
    }

    return participant.color;
  }

  public select(square: Square) {
    if (square.piece !== null) {
      this.clientService.possibleMoves(square.position).subscribe({
        next: x => {
          if (x.isSuccessful) {
            this.selectedSquare.set(square);
            this.possibleMoves.set(x.value)
          } else {
            this.selectedSquare.set(null);
            this.possibleMoves.set([]);
            this.errorNotificationSource.next(x.errorMessage);
          }
        },
        error: err => this.errorNotificationSource.next(this.extractError(err))
    });
    }

    if (this.selectedSquare() !== null && square.piece === null) {
      const selectedSquare: Square = this.selectedSquare()!;
      const move: Move = {from: selectedSquare.position, to: square.position};
      this.clientService.move(move).subscribe({
        next: x => {
          if (x.isSuccessful) {
            const boardData = this.toBoardData(x.value);
            this.board.set(boardData);
            this.selectedSquare.set(null);
            this.possibleMoves.set([]);
          } else {
            this.selectedSquare.set(null);
            this.possibleMoves.set([]);
            this.errorNotificationSource.next(x.errorMessage);
          }
        },
        error: err => this.errorNotificationSource.next(this.extractError(err))
      });
    }
  }

  //TODO: Temporary solution, handle errors properly later
  private extractError(err: HttpErrorResponse): string {
    if (err?.error?.message) {
      return err.error.message;
    }

    return 'Unknown error!';
  }
}

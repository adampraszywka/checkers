import {Injectable} from "@angular/core";
import {Observable, Subject} from "rxjs";
import {BoardClientService} from "../services/board-client.service";
import {HighlightRequested} from "../events/highlight-requested.interface";
import {Highlight} from "../square/highlight.enum";
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

  private selectedSquare: Square|null = null;
  private possibleMoves: PossibleMove[]|null = null;

  private readonly errorNotificationSource: Subject<string> = new Subject<string>();
  private readonly boardUpdatedSource: Subject<BoardData> = new Subject<BoardData>();
  private readonly squareHighlightChangeRequestedSource: Subject<HighlightRequested> = new Subject<HighlightRequested>();

  public readonly errorNotificationRequested$: Observable<string> = this.errorNotificationSource.asObservable();
  public readonly boardUpdateRequested$: Observable<BoardData> = this.boardUpdatedSource.asObservable();
  public readonly squareHighlightChangeRequested$: Observable<HighlightRequested> = this.squareHighlightChangeRequestedSource.asObservable();

  public constructor(private readonly clientService: BoardClientService, private readonly idProvider: PlayerIdProvider) {
  }

  public initialize(boardId: string): void {
    this.clientService.dashboardUpdatedRequested.subscribe(board => {
      const boardData = this.toBoardData(board);
      this.boardUpdatedSource.next(boardData);
    });
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
      if (this.selectedSquare !== null) {
        this.squareHighlightChangeRequestedSource.next({position: this.selectedSquare.position, type: Highlight.None});
      }

      if (this.possibleMoves !== null) {
        for(const move of this.possibleMoves) {
          this.squareHighlightChangeRequestedSource.next({position: move.to, type: Highlight.None});
        }
      }



      this.clientService.possibleMoves(square.position).subscribe({
        next: x => {
          if (x.isSuccessful) {
            this.selectedSquare = square;
            this.squareHighlightChangeRequestedSource.next({position: square.position, type: Highlight.Selected});
            this.possibleMoves = x.value;
            for (const move of x.value) {
              this.squareHighlightChangeRequestedSource.next({position: move.to, type: Highlight.Target});
            }
          } else {
            this.errorNotificationSource.next(x.errorMessage);
          }
        },
        error: err => this.errorNotificationSource.next(this.extractError(err))
    });
    }

    if (this.selectedSquare !== null && square.piece === null) {
      const move: Move = {from: this.selectedSquare.position, to: square.position};
      this.clientService.move(move).subscribe({
        next: x => {
          if (x.isSuccessful) {
            const boardData = this.toBoardData(x.value);
            this.boardUpdatedSource.next(boardData)
            this.selectedSquare = null;
          } else {
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

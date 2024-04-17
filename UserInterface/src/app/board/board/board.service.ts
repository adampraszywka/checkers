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

@Injectable()
export class BoardService {

  private selectedSquare: Square|null = null;
  private possibleMoves: PossibleMove[]|null = null;

  private readonly errorNotificationSource: Subject<string> = new Subject<string>();
  private readonly boardUpdatedSource: Subject<Board> = new Subject<Board>();
  private readonly squareHighlightChangeRequestedSource: Subject<HighlightRequested> = new Subject<HighlightRequested>();

  public readonly errorNotificationRequested$: Observable<string> = this.errorNotificationSource.asObservable();
  public readonly boardUpdateRequested$: Observable<Board> = this.boardUpdatedSource.asObservable();
  public readonly squareHighlightChangeRequested$: Observable<HighlightRequested> = this.squareHighlightChangeRequestedSource.asObservable();

  public constructor(private readonly clientService: BoardClientService) {
  }

  public initialize(boardId: string): void {
    this.clientService.dashboardUpdatedRequested.subscribe(b => this.boardUpdatedSource.next(b));
    this.clientService.initialize(boardId);
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

      this.selectedSquare = square;
      this.squareHighlightChangeRequestedSource.next({position: square.position, type: Highlight.Selected});

      this.clientService.possibleMoves(square.position).subscribe({
        next: x => {
          if (x.isSuccessful) {
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
            this.boardUpdatedSource.next(x.value)
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

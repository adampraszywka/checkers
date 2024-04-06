import {Injectable} from "@angular/core";
import {Observable, Subject} from "rxjs";
import {Square} from "../dto/square.interface";
import {Move} from "../dto/move.interface";
import {ApiClientService} from "../services/api-client.service";
import {Board} from "../dto/board.interface";
import {HighlightRequested} from "../events/highlight-requested.interface";
import {Highlight} from "../square/highlight.enum";
import {PossibleMove} from "../dto/possiblemove.interface";
import {HttpErrorResponse} from "@angular/common/http";

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

  public constructor(private readonly apiClient: ApiClientService) {
  }

  public initialize(): void {
    this.apiClient.get().subscribe(x => this.boardUpdatedSource.next(x));
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

      this.apiClient.possibleMoves(square.position).subscribe({
        next: x => {
          this.possibleMoves = x;
          for (const move of x) {
            this.squareHighlightChangeRequestedSource.next({position: move.to, type: Highlight.Target});
          }
        },
        error: err => this.errorNotificationSource.next(this.extractError(err))
    });
    }

    if (this.selectedSquare !== null && square.piece === null) {
      const move: Move = {from: this.selectedSquare.position, to: square.position};
      this.apiClient.move(move).subscribe({
        next: x => {
          this.boardUpdatedSource.next(x)
          this.selectedSquare = null;
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

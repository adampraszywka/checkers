import {Injectable} from "@angular/core";
import {Observable, Subject} from "rxjs";
import {Square} from "../dto/square.interface";
import {Move} from "../dto/move.interface";
import {ApiClientService} from "../services/api-client.service";
import {Board} from "../dto/board.interface";
import {HighlightRequested} from "../events/highlight-requested.interface";
import {Highlight} from "../square/highlight.enum";

@Injectable()
export class BoardService {

  private selectedSquare: Square|null = null;

  private readonly boardUpdatedSource: Subject<Board> = new Subject<Board>();
  private readonly squareHighlightChangeRequestedSource: Subject<HighlightRequested> = new Subject<HighlightRequested>();

  public readonly boardUpdateRequested: Observable<Board> = this.boardUpdatedSource.asObservable();
  public readonly squareHighlightChangeRequested$: Observable<HighlightRequested> = this.squareHighlightChangeRequestedSource.asObservable();

  public constructor(private readonly apiClient: ApiClientService) {
  }

  public initialize(): void {
    this.apiClient.get().subscribe(x => this.boardUpdatedSource.next(x));
  }

  public select(square: Square) {
    if (this.selectedSquare === null && square.piece !== null) {
      this.selectedSquare = square;
      this.squareHighlightChangeRequestedSource.next({position: square.position, type: Highlight.Selected});

      this.apiClient.possibleMoves(square.position).subscribe(x => {
        for(const move of x) {
          this.squareHighlightChangeRequestedSource.next({position: move.to, type: Highlight.Target});
        }
      });
    }

    if (this.selectedSquare !== null && square.piece === null) {
      const move: Move = {from: this.selectedSquare.position, to: square.position};
      this.apiClient.move(move).subscribe(x => this.boardUpdatedSource.next(x));
      this.selectedSquare = null;
    }
  }
}

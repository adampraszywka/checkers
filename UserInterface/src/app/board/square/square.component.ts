import {Component, inject, input, OnDestroy, signal} from '@angular/core';
import {NgClass, NgIf} from "@angular/common";
import {PieceComponent} from "../piece/piece.component";
import {BoardService} from "../board/board.service";
import {Highlight} from "./highlight.enum";
import {Subscription} from "rxjs";
import {Square} from "../../shared/dto/square.interface";

@Component({
  selector: 'app-square[square][row][column]',
  standalone: true,
  imports: [
    NgClass,
    PieceComponent,
    NgIf
  ],
  templateUrl: './square.component.html',
  styleUrl: './square.component.scss'
})
export class SquareComponent implements OnDestroy {
  service = inject(BoardService);

  square = input<Square>({id: '', position: {row: 0, column: 0}, piece: null});
  row = input<number>(0);
  column = input<number>(0);

  highlight = signal(Highlight.None);
  private readonly highlightSubscription: Subscription;

  public constructor() {
    this.highlightSubscription = this.service.squareHighlightChangeRequested$.subscribe(x => {
      if (x.position.row === this.square().position.row && x.position.column === this.square().position.column) {
        this.highlight.set(x.type);
      }
    })
  }

  ngOnDestroy(): void {
    this.highlightSubscription.unsubscribe();
  }

  public isBlackSquare(): boolean {
    if (this.row() % 2 !== 0) {
      return this.column() % 2 === 0;
    }

    return this.column() % 2 !== 0;
  }

  public getCssClass(): string {
    if (this.highlight()== Highlight.None) {
      return this.isBlackSquare() ? 'black' : 'white';
    }
    else if (this.highlight() === Highlight.Selected) {
      return 'selected';
    }
    else {
      return 'target';
    }
  }

  public onClick(): void {
    this.service.select(this.square());
  }
}

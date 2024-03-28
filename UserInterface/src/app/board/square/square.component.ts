import {Component, Input, OnDestroy} from '@angular/core';
import {Square} from "../dto/square.interface";
import {NgClass, NgIf} from "@angular/common";
import {PieceComponent} from "../piece/piece.component";
import {BoardService} from "../board/board.service";
import {Highlight} from "./highlight.enum";
import {Subscription} from "rxjs";

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
  @Input() square!: Square;
  @Input() row!: number;
  @Input() column!: number;

  private highlight: Highlight = Highlight.None;
  private readonly highlightSubscription: Subscription;

  public constructor(private readonly service: BoardService) {
    this.highlightSubscription = this.service.squareHighlightChangeRequested$.subscribe(x => {
      if (x.position.row === this.square.position.row && x.position.column === this.square.position.column) {
        console.log(x);
        this.highlight = x.type;
      }
    })
  }

  ngOnDestroy(): void {
    this.highlightSubscription.unsubscribe();
  }

  public isBlackSquare(): boolean {
    if (this.row % 2 !== 0) {
      return this.column % 2 === 0;
    }

    return this.column % 2 !== 0;
  }

  public getCssClass(): string {
    if (this.highlight === Highlight.None) {
      return this.isBlackSquare() ? 'black' : 'white';
    }
    else if (this.highlight === Highlight.Selected) {
      return 'selected';
    }
    else {
      return 'target';
    }
  }

  public onClick(): void {
    this.service.select(this.square);
  }
}

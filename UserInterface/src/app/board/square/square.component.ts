import {Component, computed, inject, input} from '@angular/core';
import {NgClass, NgIf} from "@angular/common";
import {PieceComponent} from "../piece/piece.component";
import {BoardService} from "../board/board.service";
import {Highlight} from "./highlight.enum";
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
export class SquareComponent {
  private readonly service = inject(BoardService);

  readonly square = input<Square>({id: '', position: {row: 0, column: 0}, piece: null});
  readonly row = input<number>(0);
  readonly column = input<number>(0);

  readonly highlight = computed(() => {
    const me = this.square();

    if (this.service.selectedSquare()?.id === me.id) {
      return Highlight.Selected;
    }

    if (this.service.possibleMoves().find(x => x.to.row === me.position.row && x.to.column === me.position.column)) {
      return Highlight.Target;
    }

    return Highlight.None;
  })

  readonly cssClasses = computed<string>(() => {
    if (this.highlight()== Highlight.None) {
      return this.isBlackSquare() ? 'black' : 'white';
    }
    else if (this.highlight() === Highlight.Selected) {
      return 'selected';
    }
    else {
      return 'target';
    }
  });

  private isBlackSquare(): boolean {
    if (this.row() % 2 !== 0) {
      return this.column() % 2 === 0;
    }

    return this.column() % 2 !== 0;
  }

  public onClick(): void {
    this.service.select(this.square());
  }
}

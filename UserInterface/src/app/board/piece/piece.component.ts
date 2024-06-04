import {Component, computed, input} from '@angular/core';
import {NgClass} from "@angular/common";
import {Color, Piece, Type} from "../../shared/dto/piece.interface";

@Component({
  selector: 'app-piece[piece]',
  standalone: true,
  imports: [
    NgClass
  ],
  templateUrl: './piece.component.html',
  styleUrl: './piece.component.scss'
})
export class PieceComponent {
  piece = input<Piece>({id: '', color: Color.Black, type: Type.Man});
  cssClasses = computed<string>(() => {
    const color = this.piece().color === Color.Black ? 'black' : 'white';

    if (this.piece().type === Type.Man) {
      return `${color} man`
    }

    return `${color} king`
  });

  protected readonly Color = Color;
}

import {Component, input} from '@angular/core';
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

  protected readonly Color = Color;

  public get cssClasses(): string {
    const color = this.piece().color === Color.Black ? 'black' : 'white';

    if (this.piece().type === Type.Man) {
      return `${color} man`
    }

    return `${color} king`
  }
}

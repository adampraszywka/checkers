import {Component, Input} from '@angular/core';
import {Color, Piece, Type} from "../dto/piece.interface";
import {NgClass} from "@angular/common";

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
  @Input() piece!: Piece;
  protected readonly Color = Color;

  public get cssClasses(): string {
    const color = this.piece.color === Color.Black ? 'black' : 'white';

    if (this.piece.type === Type.Man) {
      return `${color} man`
    }

    return `${color} king`
  }
}

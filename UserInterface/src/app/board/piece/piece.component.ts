import {Component, Input} from '@angular/core';
import {Color, Piece} from "../dto/piece.interface";
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
}

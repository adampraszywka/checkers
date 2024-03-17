import {Component, Input} from '@angular/core';
import {Square} from "../dto/square.interface";
import {NgClass, NgIf} from "@angular/common";
import {PieceComponent} from "../piece/piece.component";

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
  @Input() square!: Square;
  @Input() row!: number;
  @Input() column!: number;

  isBlackSquare(): boolean {
    if (this.row % 2 !== 0) {
      return this.column % 2 === 0;
    }

    return this.column % 2 !== 0;
  }

}

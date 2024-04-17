import {Piece} from "./piece.interface";
import {Position} from "./position.interface";

export interface Square {
  readonly id: string
  readonly piece: Piece|null;
  readonly position: Position;
}

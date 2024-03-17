import {Piece} from "./piece.interface";

export interface Square {
  readonly id: string
  readonly piece: Piece|null;
}

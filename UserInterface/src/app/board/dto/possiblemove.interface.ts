import {Position} from "./position.interface";

export interface PossibleMove {
  readonly to: Position;
  readonly affectedSquares: Position[];
  readonly capturedPieces: number;
}

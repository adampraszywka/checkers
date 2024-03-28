import {Position} from "./position.interface";

export interface Move {
  readonly to: Position;
  readonly from: Position;
}

import {Board} from "../../shared/dto/board.interface";
import {Color} from "../../shared/dto/piece.interface";

export interface BoardData {
  readonly board: Board;
  readonly playerColor: Color;
}

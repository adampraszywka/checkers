import {Piece} from "./piece.interface";
import {Position} from "./position.interface";
import {MoveLogEntryPosition} from "./move-log-entry-position.interface";

export interface MoveLogEntry {
  readonly piece: Piece;
  readonly from: MoveLogEntryPosition;
  readonly to: MoveLogEntryPosition;
}

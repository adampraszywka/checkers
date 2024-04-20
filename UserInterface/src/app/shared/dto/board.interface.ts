import {Square} from "./square.interface";
import {Color} from "./piece.interface";
import {MoveLogEntry} from "./move-log-entry.interface";
import {Participant} from "./participant.interface";

export interface Board {
  readonly id: string;
  readonly columns: number;
  readonly rows: number;
  readonly squares: Square[][];
  readonly currentPlayer: Color;
  readonly moveLog: MoveLogEntry[];
  readonly participants: Participant[];
}


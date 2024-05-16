import { Color } from "./piece.interface";

export interface Participant {
  readonly id: string;
  readonly color: Color;
  readonly bot: boolean;
}

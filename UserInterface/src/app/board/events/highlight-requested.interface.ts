import {Highlight} from "../square/highlight.enum";
import {Position} from "../../shared/dto/position.interface";

export interface HighlightRequested {
  readonly position: Position;
  readonly type: Highlight;
}

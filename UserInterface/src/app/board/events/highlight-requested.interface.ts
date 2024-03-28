import {Highlight} from "../square/highlight.enum";
import {Position} from "../dto/position.interface";

export interface HighlightRequested {
  readonly position: Position;
  readonly type: Highlight;
}

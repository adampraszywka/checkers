import {Kind} from "./kind";

export interface AiPlayerStatus {
  readonly timestamp: number;
  readonly kind: Kind;
  readonly context: string;
  readonly data: string;
}

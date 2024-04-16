import {Square} from "./square.interface";

export interface Board {
  readonly id: string;
  readonly columns: number;
  readonly rows: number;
  readonly squares: Square[][];
}


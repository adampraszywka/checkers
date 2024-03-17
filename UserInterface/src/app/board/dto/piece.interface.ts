export interface Piece {
  readonly id: string;
  readonly color: Color;
  readonly type: Type;
}

export enum Type {
  Man = 0, King = 1
}

export enum Color {
  Black = 0, White = 1
}

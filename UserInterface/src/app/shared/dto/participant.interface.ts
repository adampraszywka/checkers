export interface Participant {
  readonly name: string;
  readonly color: ParticipantColor;
}

enum ParticipantColor {
  Black = 0, White = 1
}

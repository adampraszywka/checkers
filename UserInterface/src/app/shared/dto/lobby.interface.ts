import {Participant} from "./participant.interface";

export interface Lobby {
  readonly id: string;
  readonly name: string;
  readonly boardId: string|null;
  readonly players: number;
  readonly maxPlayers: number;
  readonly status: LobbyStatus;
  readonly participants: Participant[];
}

export enum LobbyStatus {
  WaitingForPlayers, ReadyToStart, Closed
}

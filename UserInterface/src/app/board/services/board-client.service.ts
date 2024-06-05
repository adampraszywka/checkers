import {inject, Injectable, signal} from '@angular/core';
import {from, Observable} from "rxjs";
import {ApiConfiguration} from "../../app.config";
import {Board} from "../../shared/dto/board.interface";
import {Position} from "../../shared/dto/position.interface";
import {PossibleMove} from "../../shared/dto/possiblemove.interface";
import {Move} from "../../shared/dto/move.interface";
import {HubConnection, HubConnectionBuilder} from "@microsoft/signalr";
import {PlayerIdProvider} from "../../shared/authorization/playerid-provider.service";
import {ActionResult} from "../../shared/dto/action-result.interface";
import {Color} from "../../shared/dto/piece.interface";

const emptyBoard: Board = {
  id: '', moveLog: [], participants: [], squares: [], currentPlayer: Color.White, columns: 0, rows: 0
}

@Injectable({
  providedIn: 'root'
})
export class BoardClientService {
  private readonly config = inject(ApiConfiguration);
  private readonly playerIdProvider = inject(PlayerIdProvider);
  readonly board = signal<Board>(emptyBoard);

  private hubConnection!: HubConnection;

  public initialize(boardId: string): void {
    const playerId = this.playerIdProvider.get();
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.config.baseUrl + 'hub_board?boardId=' + boardId + '&playerId=' + playerId)
      .build();

    this.hubConnection.start()
      .then(() => {console.log("SignalR alive!")})
      .catch(err => console.log('Error while starting SignalR connection: ', err));

    this.hubConnection.on('BoardUpdated', (board: Board) => this.board.set(board));
  }

  public possibleMoves(position: Position): Observable<ActionResult<PossibleMove[]>> {
    return from(this.hubConnection.invoke<ActionResult<PossibleMove[]>>('PossibleMoves', position));
  }

  public move(move: Move): Observable<ActionResult<Board>> {
    return from(this.hubConnection.invoke<ActionResult<Board>>('Move', move));
  }
}


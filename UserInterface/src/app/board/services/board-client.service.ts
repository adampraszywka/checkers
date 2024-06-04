import { Injectable } from '@angular/core';
import {from, Observable, Subject} from "rxjs";
import {ApiConfiguration} from "../../app.config";
import {Board} from "../../shared/dto/board.interface";
import {Position} from "../../shared/dto/position.interface";
import {PossibleMove} from "../../shared/dto/possiblemove.interface";
import {Move} from "../../shared/dto/move.interface";
import {HubConnection, HubConnectionBuilder} from "@microsoft/signalr";
import {PlayerIdProvider} from "../../shared/authorization/playerid-provider.service";
import {ActionResult} from "../../shared/dto/action-result.interface";

@Injectable({
  providedIn: 'root'
})
export class BoardClientService {
  private hubConnection!: HubConnection;

  private readonly dashboardUpdatedSource: Subject<Board> = new Subject<Board>();
  public readonly dashboardUpdatedRequested: Observable<Board> = this.dashboardUpdatedSource.asObservable();

  constructor(private readonly config: ApiConfiguration, private readonly playerIdProvider: PlayerIdProvider) {
  }

  public initialize(boardId: string): void {
    const playerId = this.playerIdProvider.get();
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.config.baseUrl + 'hub_board?boardId=' + boardId + '&playerId=' + playerId)
      .build();

    this.hubConnection.start()
      .then(() => {console.log("SignalR alive!")})
      .catch(err => console.log('Error while starting SignalR connection: ', err));

    this.hubConnection.on('BoardUpdated', (board: Board) => this.dashboardUpdatedSource.next(board));
  }

  public possibleMoves(position: Position): Observable<ActionResult<PossibleMove[]>> {
    return from(this.hubConnection.invoke<ActionResult<PossibleMove[]>>('PossibleMoves', position));
  }

  public move(move: Move): Observable<ActionResult<Board>> {
    return from(this.hubConnection.invoke<ActionResult<Board>>('Move', move));
  }
}


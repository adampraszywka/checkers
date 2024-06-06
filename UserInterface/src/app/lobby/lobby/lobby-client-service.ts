import {inject, Injectable, signal} from "@angular/core";
import {HubConnection, HubConnectionBuilder} from "@microsoft/signalr";
import {Lobby, LobbyStatus} from "../../shared/dto/lobby.interface";
import {ApiConfiguration} from "../../app.config";
import {PlayerIdProvider} from "../../shared/authorization/playerid-provider.service";
import {ActionResult} from "../../shared/dto/action-result.interface";
import {Board} from "../../shared/dto/board.interface";
import {AiPlayer} from "../../shared/dto/ai-player.interface";

const emptyLobby: Lobby = {id: '', status: LobbyStatus.WaitingForPlayers, participants: [], players: 0, maxPlayers: 0, boardId: null, name: ''};

@Injectable()
export class LobbyClientService {
  private readonly config = inject(ApiConfiguration);
  private readonly playerIdProvider = inject(PlayerIdProvider);

  private hubConnection!: HubConnection;

  readonly lobby = signal<Lobby>(emptyLobby);

  public initialize(lobbyId: string): void {
    const playerId = this.playerIdProvider.get();
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.config.baseUrl + 'hub_lobby?lobbyId=' + lobbyId + '&playerId=' + playerId)
      .build();

    this.hubConnection.start()
      .then(() => console.log("SignalR alive!"))
      .catch(err => console.log('Error while starting SignalR connection: ', err));

    this.hubConnection.on('LobbyUpdated', (lobby: Lobby) => this.lobby.set(lobby));
  }

  public close(): Promise<ActionResult<Board>> {
    return this.hubConnection.invoke<ActionResult<Board>>('Close');
  }

  public listAiPlayers(): Promise<AiPlayer[]> {
    return this.hubConnection.invoke<AiPlayer[]>('ListAiPlayers');
  }

  public addAiPlayer(aiPlayerType: string): Promise<ActionResult<Lobby>> {
    return this.hubConnection.invoke<ActionResult<Lobby>>('AddAiPlayer', aiPlayerType);
  }

}

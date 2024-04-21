import {Injectable} from "@angular/core";
import {HubConnection, HubConnectionBuilder} from "@microsoft/signalr";
import {Observable, Subject} from "rxjs";
import {Lobby} from "../../shared/dto/lobby.interface";
import {ApiConfiguration} from "../../app.config";
import {PlayerIdProvider} from "../../shared/authorization/playerid-provider.service";
import {ActionResult} from "../../shared/dto/action-result.interface";
import {Board} from "../../shared/dto/board.interface";
import {AiPlayer} from "../../shared/dto/ai-player.interface";

@Injectable()
export class LobbyClientService {
  private hubConnection!: HubConnection;

  private readonly lobbyUpdatedSource: Subject<Lobby> = new Subject<Lobby>();
  public readonly lobbyUpdatedRequested$: Observable<Lobby> = this.lobbyUpdatedSource.asObservable();

  constructor(private readonly config: ApiConfiguration, private readonly playerIdProvider: PlayerIdProvider) {}

  public initialize(lobbyId: string): void {
    const playerId = this.playerIdProvider.get();
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.config.baseUrl + 'hub_lobby?lobbyId=' + lobbyId + '&playerId=' + playerId)
      .build();

    this.hubConnection.start()
      .then(() => {
        console.log("SignalR alive!")
      })
      .catch(err => console.log('Error while starting SignalR connection: ', err));

    this.hubConnection.on('LobbyUpdated', (lobby: Lobby) => this.lobbyUpdatedSource.next(lobby));
  }

  public close(): Promise<ActionResult<Board>> {
    return this.hubConnection.invoke<ActionResult<Board>>('Close');
  }

  public listAiPlayers(): Promise<AiPlayer[]> {
    return this.hubConnection.invoke<AiPlayer[]>('ListAiPlayers');
  }

  public addAiPlayer(aiPlayerType: string): Promise<ActionResult<Lobby>> {
    console.log(aiPlayerType);
    return this.hubConnection.invoke<ActionResult<Lobby>>('AddAiPlayer', aiPlayerType);
  }

}

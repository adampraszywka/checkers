import {Injectable} from "@angular/core";
import {HubConnection, HubConnectionBuilder} from "@microsoft/signalr";
import {Observable, Subject} from "rxjs";
import {AiPlayerStatusUpdated} from "./ai-player-status-updated.interface";
import {ApiConfiguration} from "../app.config";
import {AiPlayerStatus} from "./ai-player-status.interface";

@Injectable()
export class AiStatusClient {
  private hubConnection!: HubConnection;

  private readonly statusUpdatedSource: Subject<AiPlayerStatus[]> = new Subject<AiPlayerStatus[]>();
  public readonly statusUpdateRequested$: Observable<AiPlayerStatus[]> = this.statusUpdatedSource.asObservable();

  constructor(private readonly config: ApiConfiguration) {}

  public initialize(boardId: string): void {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.config.baseUrl + 'hub_aistatus?boardId=' + boardId)
      .build();

    this.hubConnection.start()
      .then(() => {
        console.log("SignalR alive!")
      })
      .catch(err => console.log('Error while starting SignalR connection: ', err));

    this.hubConnection.on('StatusUpdated', (status: AiPlayerStatusUpdated) => this.statusUpdatedSource.next(status.entries));
  }

}

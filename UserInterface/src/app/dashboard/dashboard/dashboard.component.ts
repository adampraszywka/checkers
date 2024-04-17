import {Component, OnDestroy} from '@angular/core';
import {CommonModule} from "@angular/common";
import {Lobby} from "../../shared/dto/lobby.interface";
import {DashboardLobbyComponent} from "../dashboard-lobby/dashboard-lobby.component";
import {DashboardClientService} from "./dashboard-client.service";
import {Subscription} from "rxjs";
import { v4 as uuidv4 } from 'uuid';
import {Router} from "@angular/router";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {DashboardLobbyCreateComponent, ModalResult} from "../dashboard-lobby-create/dashboard-lobby-create.component";

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, DashboardLobbyComponent],
  providers: [
    {provide: DashboardClientService}
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent implements OnDestroy {

  public lobbies: Lobby[] = [];
  private readonly lobbiesUpdatedSubscription: Subscription;

  constructor(
    private readonly clientService: DashboardClientService,
    private readonly router: Router,
    private readonly modal: NgbModal) {
    this.lobbiesUpdatedSubscription = clientService.lobbiesUpdatedRequested$.subscribe(x => this.lobbies = x);
  }

  joinLobby(id: string) {
    this.clientService.join(id).then(x => {
      const lobbyId = x.value.id;
      this.router.navigate(['lobby/' + lobbyId])
    })
  }

  createLobby(): void {
    this.modal.open(DashboardLobbyCreateComponent).result.then((x: ModalResult) => {
      if (!x.isFinalized) {
        return;
      }

      this.clientService.createLobby(x.value).then(x => {
        const lobbyId = x.value.id;
        this.router.navigate(['lobby/' + lobbyId])
      })
    });
  }


  ngOnDestroy(): void {
    this.lobbiesUpdatedSubscription.unsubscribe();
  }
}

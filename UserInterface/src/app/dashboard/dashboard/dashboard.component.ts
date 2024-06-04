import {Component, computed, inject} from '@angular/core';
import {CommonModule} from "@angular/common";
import {Lobby, LobbyStatus} from "../../shared/dto/lobby.interface";
import {DashboardClientService} from "./dashboard-client.service";
import {Router} from "@angular/router";
import {NgbAlert, NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {DashboardLobbyCreateComponent} from "../dashboard-lobby-create/dashboard-lobby-create.component";
import {ModalResult} from "../../shared/result/modal-result";
import {ToastrModule, ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, ToastrModule, NgbAlert],
  providers: [
    {provide: DashboardClientService}
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {
  clientService = inject(DashboardClientService);
  router = inject(Router);
  modal = inject(NgbModal);
  toastr = inject(ToastrService);

  lobbies = computed<Lobby[]>(() => this.clientService.lobbies());

  joinLobby(id: string) {
    this.clientService.join(id).then(x => {
      if (!x.isSuccessful) {
        if (x.errorCode === 'LOBBY_JOIN_FAILED_PLAYER_ALREADY_IN_THE_LOBBY') {
          this.router.navigate(['lobby/' + id]).then();
          return;
        }

        this.toastr.error(x.errorMessage, 'Failed to join lobby');
      } else {
        const lobbyId = x.value.id;
        this.router.navigate(['lobby/' + lobbyId]).then();
      }
    })
  }

  createLobby(): void {
    this.modal.open(DashboardLobbyCreateComponent).result.then((x: ModalResult) => {
      if (!x.isFinalized) {
        return;
      }

      this.clientService.createLobby(x.value).then(x => {
        if (!x.isSuccessful) {
          this.toastr.error(x.errorMessage, 'Failed to create lobby');
          return;
        }

        const lobbyId = x.value.id;
        this.router.navigate(['lobby/' + lobbyId]).then()
      })
    });
  }

  protected readonly LobbyStatus = LobbyStatus;
}

import {Component, computed, effect, inject, input, Input, OnInit} from '@angular/core';
import {LobbyClientService} from "./lobby-client-service";
import {CommonModule} from "@angular/common";
import {Router} from "@angular/router";
import {Lobby, LobbyStatus} from "../../shared/dto/lobby.interface";
import {Color} from "../../shared/dto/piece.interface";
import {ModalResult} from "../../shared/result/modal-result";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {LobbyAddAiPlayerComponent} from "../lobby-add-ai-player/lobby-add-ai-player.component";
import {ToastrModule, ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-lobby',
  standalone: true,
  imports: [CommonModule, ToastrModule],
  providers: [
    LobbyClientService
  ],
  templateUrl: './lobby.component.html',
  styleUrl: './lobby.component.scss'
})
export class LobbyComponent implements OnInit {
  private readonly client = inject(LobbyClientService);
  private readonly router = inject(Router);
  private readonly modal = inject(NgbModal);
  private readonly toastr = inject(ToastrService);

  readonly lobbyId = input('');
  readonly lobby = computed<Lobby>(() => this.client.lobby());

  _ = effect(() => {
    const lobby = this.lobby();
    if (lobby.status === LobbyStatus.Closed && lobby.boardId !== null) {
      this.router.navigate(['board/' + lobby.boardId]).then()
    }
  });

  protected readonly LobbyStatus = LobbyStatus;
  protected readonly Color = Color;

  ngOnInit(): void {
    this.client.initialize(this.lobbyId());
  }

  onClose() {
    this.client.close().then(x => {
      if (!x.isSuccessful) {
        this.toastr.error(x.errorMessage, 'Failed to close lobby');
      }
    });
  }

  onAddAiPlayer() {
    this.client.listAiPlayers().then(x => {
      const modalRef = this.modal.open(LobbyAddAiPlayerComponent);
      const component: LobbyAddAiPlayerComponent = modalRef.componentInstance;
      component.aiPlayers = x;

      modalRef.result.then((x: ModalResult) => {
        if (!x.isFinalized) {
          return;
        }

        this.client.addAiPlayer(x.value).then(x => {
          if (!x.isSuccessful) {
            this.toastr.error(x.errorMessage, 'Failed to add AI player');
            return;
          }
        })
      });
    });
  }
}

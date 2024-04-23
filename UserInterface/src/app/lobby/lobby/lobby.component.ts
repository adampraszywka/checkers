import {Component, Input, OnInit} from '@angular/core';
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
  @Input() lobbyId!: string;
  public lobby: Lobby|null = null;

  protected readonly LobbyStatus = LobbyStatus;
  protected readonly Color = Color;

  constructor(
    private readonly client: LobbyClientService,
    private readonly router: Router,
    private readonly modal: NgbModal,
    private readonly toastr: ToastrService) {}

  ngOnInit(): void {
    this.client.initialize(this.lobbyId);
    this.client.lobbyUpdatedRequested$.subscribe(x => {
      if (x.status === LobbyStatus.Closed && x.boardId !== null) {
        this.router.navigate(['board/' + x.boardId]).then()
      } else {
        this.lobby = x;
      }
    })
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

          this.lobby = x.value;
        })
      });
    });
  }
}

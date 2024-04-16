import {Component, EventEmitter, Input, Output} from '@angular/core';
import {CommonModule} from "@angular/common";
import {Lobby} from "../../shared/dto/lobby.interface";

@Component({
  selector: 'app-dashboard-lobby[lobby]',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard-lobby.component.html',
  styleUrl: './dashboard-lobby.component.scss'
})
export class DashboardLobbyComponent {
  @Input() public lobby!: Lobby;
  @Output() public joinRequested: EventEmitter<string> = new EventEmitter<string>();

  public onJoinClick() {
    this.joinRequested.emit(this.lobby.id);
  }
}

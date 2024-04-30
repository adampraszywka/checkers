import {Component, Input, OnInit} from '@angular/core';
import {FormControl, ReactiveFormsModule} from "@angular/forms";
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {AiPlayer} from "../../shared/dto/ai-player.interface";
import {ModalResult} from "../../shared/result/modal-result";

@Component({
  selector: 'app-lobby-add-ai-player',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './lobby-add-ai-player.component.html',
  styleUrl: './lobby-add-ai-player.component.scss'
})
export class LobbyAddAiPlayerComponent implements OnInit {
  @Input() aiPlayers: AiPlayer[] = [];

  public type: FormControl<string>;
  constructor(public readonly modal: NgbActiveModal) {
    this.type = new FormControl<string>(this.aiPlayers[0]?.type, {nonNullable: true});

  }

  ngOnInit(): void {
    this.type.setValue(this.aiPlayers[0]?.type);
  }

  onCreate(): void {
    this.modal.close(new ModalResult(this.type.value));
  }

  onCancel(): void {
    this.modal.dismiss(new ModalResult(null));
  }
}

import {Component, computed, input} from '@angular/core';
import {MoveLogEntry} from "../../shared/dto/move-log-entry.interface";
import {Color, Type} from "../../shared/dto/piece.interface";
import {CommonModule} from "@angular/common";

@Component({
  selector: 'app-move-log[moveLog]',
  standalone: true,
  imports: [
    CommonModule
  ],
  templateUrl: './move-log.component.html',
  styleUrl: './move-log.component.scss'
})
export class MoveLogComponent {
  readonly moveLog = input([], {
    transform: (x: MoveLogEntry[]) => x.slice().reverse()
  });
  readonly moveLogLength = computed(() => this.moveLog().length);

  protected readonly Color = Color;
  protected readonly Type = Type;
}

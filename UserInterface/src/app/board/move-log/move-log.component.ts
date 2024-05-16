import {Component, Input} from '@angular/core';
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
  @Input('moveLog') moveLog!: MoveLogEntry[];
  protected readonly Color = Color;
  protected readonly Type = Type;
}

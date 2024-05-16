import {Component, Input, OnInit} from '@angular/core';
import {CommonModule} from "@angular/common";
import {SquareComponent} from "../square/square.component";
import {BoardService} from "./board.service";
import {ToastrModule, ToastrService} from "ngx-toastr";
import {Color, Type} from "../../shared/dto/piece.interface";
import {BoardData} from "../dto/board-data.interface";
import {NgbAlert} from "@ng-bootstrap/ng-bootstrap";
import {AiAgentComponent} from "../../ai-agent/ai-agent.component";
import {MoveLogComponent} from "../move-log/move-log.component";

@Component({
  selector: 'app-board',
  standalone: true,
  imports: [CommonModule, SquareComponent, ToastrModule, NgbAlert, AiAgentComponent, MoveLogComponent],
  templateUrl: './board.component.html',
  styleUrl: './board.component.scss',
  providers: [
    BoardService
  ]
})
export class BoardComponent implements OnInit {
  @Input() boardId!: string;
  public board: BoardData|null = null;

  public constructor(private readonly service: BoardService, private readonly toastr: ToastrService) {
    service.boardUpdateRequested$.subscribe(x => {
      this.board = x;
    });
    service.errorNotificationRequested$.subscribe(x => toastr.error(x));
  }

  ngOnInit(): void {
    this.service.initialize(this.boardId);
  }

  public botPlayerParticipates(): boolean {
    if (this.board === null) {
      return false;
    }

    return this.board.board.participants.find(x => x.bot) !== undefined;
  }

  protected readonly Color = Color;
  protected readonly Type = Type;
}

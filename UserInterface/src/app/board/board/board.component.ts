import {Component, computed, effect, inject, input, OnInit} from '@angular/core';
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
  private readonly service = inject(BoardService);
  private readonly toastr = inject(ToastrService);

  readonly boardId = input('');
  readonly board = computed<BoardData>(() => this.service.board());

  _ = effect(() => {
    const error = this.service.error();
    if (error.message.length > 0) {
      this.toastr.error(error.message);
    }
  });

  ngOnInit(): void {
    this.service.initialize(this.boardId());
  }

  public botPlayerParticipates(): boolean {
    if (this.service.board() === null) {
      return false;
    }

    return this.service.board().board.participants.find(x => x.bot) !== undefined;
  }

  protected readonly Color = Color;
  protected readonly Type = Type;
}

import {Component, Input, OnInit} from '@angular/core';
import {CommonModule} from "@angular/common";
import {SquareComponent} from "../square/square.component";
import {BoardService} from "./board.service";
import {ToastrModule, ToastrService} from "ngx-toastr";
import {Board} from "../../shared/dto/board.interface";
import {Color, Type} from "../../shared/dto/piece.interface";

@Component({
  selector: 'app-board',
  standalone: true,
  imports: [CommonModule, SquareComponent, ToastrModule],
  templateUrl: './board.component.html',
  styleUrl: './board.component.scss',
  providers: [
    BoardService
  ]
})
export class BoardComponent implements OnInit {
  @Input() boardId!: string;
  public board: Board|null = null;

  public constructor(private readonly service: BoardService, private readonly toastr: ToastrService) {
    service.boardUpdateRequested$.subscribe(x => {
      console.log(x)
      this.board = x;
    });
    service.errorNotificationRequested$.subscribe(x => toastr.error(x));
  }

  ngOnInit(): void {
    this.service.initialize(this.boardId);
  }

  protected readonly Color = Color;
  protected readonly Type = Type;
}

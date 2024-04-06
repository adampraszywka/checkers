import {Component, OnInit} from '@angular/core';
import {CommonModule} from "@angular/common";
import {SquareComponent} from "../square/square.component";
import {Board} from "../dto/board.interface";
import {BoardService} from "./board.service";
import {ToastrModule, ToastrService} from "ngx-toastr";

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

  public board: Board|null = null;

  public constructor(private readonly service: BoardService, private readonly toastr: ToastrService) {
    service.boardUpdateRequested$.subscribe(x => this.board = x);
    service.errorNotificationRequested$.subscribe(x => toastr.error(x));
  }

  ngOnInit(): void {
    this.service.initialize();
  }

}

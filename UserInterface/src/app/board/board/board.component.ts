import {Component, OnInit} from '@angular/core';
import {CommonModule} from "@angular/common";
import {ApiClientService} from "../services/api-client.service";
import {SquareComponent} from "../square/square.component";
import {Board} from "../dto/board.interface";

@Component({
  selector: 'app-board',
  standalone: true,
  imports: [CommonModule, SquareComponent],
  templateUrl: './board.component.html',
  styleUrl: './board.component.scss'
})
export class BoardComponent implements OnInit {

  public board: Board|null = null;

  public constructor(private readonly client: ApiClientService) {
  }

  ngOnInit(): void {
    this.client.get().subscribe(x => {
      this.board = x;
    })
  }

}

import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {BoardApiConfiguration} from "../../app.config";
import {Board} from "../dto/board.interface";
import {Move} from "../dto/move.interface";
import {PossibleMove} from "../dto/possiblemove.interface";
import {Position} from "../dto/position.interface";

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {
  private readonly boardId: string = 'myBoard';
  public constructor(
    private readonly config: BoardApiConfiguration,
    private readonly httpClient: HttpClient) { }

  public get(): Observable<Board> {
    return this.httpClient.get<Board>(this.config.baseUrl + 'board/' + this.boardId);
  }

  public possibleMoves(position: Position): Observable<PossibleMove[]> {
    return this.httpClient.get<PossibleMove[]>(this.config.baseUrl + 'board/' + this.boardId + '/possiblemove/' + position.row + '/' + position.column);
  }

  public move(move: Move): Observable<Board> {
    return this.httpClient.post<Board>(this.config.baseUrl + 'board/' + this.boardId + '/move', move)
  }
}


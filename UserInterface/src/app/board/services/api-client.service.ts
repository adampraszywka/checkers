import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {BoardApiConfiguration} from "../../app.config";
import {Board} from "../dto/board.interface";

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {
  constructor(
    private readonly config: BoardApiConfiguration,
    private readonly httpClient: HttpClient) { }

  public get(): Observable<Board> {
    return this.httpClient.get<Board>(this.config.baseUrl + 'board');
  }
}


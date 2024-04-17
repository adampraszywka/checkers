import {Injectable} from "@angular/core";
import {ApiConfiguration} from "../app.config";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Ping} from "./ping.interface";

@Injectable()
export class ApiClient {
  constructor(private readonly config: ApiConfiguration, private readonly client: HttpClient) {}

  public ping(): Observable<Ping> {
    return this.client.get<Ping>(this.config.baseUrl + 'ping')
  }
}

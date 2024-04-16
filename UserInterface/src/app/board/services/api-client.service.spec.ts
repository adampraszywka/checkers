import { TestBed } from '@angular/core/testing';

import { BoardClientService } from './board-client.service';
import {provideHttpClient} from "@angular/common/http";
import {ApiConfiguration} from "../../app.config";

describe('ApiClientService', () => {
  let service: BoardClientService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        provideHttpClient(),
        {provide: ApiConfiguration, useValue: {baseUrl: ''}}
      ]
    });
    service = TestBed.inject(BoardClientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

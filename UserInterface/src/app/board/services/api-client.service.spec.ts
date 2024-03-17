import { TestBed } from '@angular/core/testing';

import { ApiClientService } from './api-client.service';
import {provideHttpClient} from "@angular/common/http";
import {BoardApiConfiguration} from "../../app.config";

describe('ApiClientService', () => {
  let service: ApiClientService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        provideHttpClient(),
        {provide: BoardApiConfiguration, useValue: {baseUrl: ''}}
      ]
    });
    service = TestBed.inject(ApiClientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

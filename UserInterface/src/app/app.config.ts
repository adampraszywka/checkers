import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import {provideHttpClient} from "@angular/common/http";

export abstract class BoardApiConfiguration {
  abstract readonly baseUrl: string;
}

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideHttpClient(),
    {provide: BoardApiConfiguration, useValue: {baseUrl: 'http://localhost:5125/'}}
  ]

};

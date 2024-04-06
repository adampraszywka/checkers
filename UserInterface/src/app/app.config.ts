import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import {provideHttpClient} from "@angular/common/http";
import {environment} from "../environments/environment";
import {provideToastr} from "ngx-toastr";
import {provideAnimations} from "@angular/platform-browser/animations";

export abstract class BoardApiConfiguration {
  abstract readonly baseUrl: string;
}

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideHttpClient(),
    {provide: BoardApiConfiguration, useValue: environment},
    provideToastr(),
    provideAnimations()
  ]

};

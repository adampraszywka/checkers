import { ApplicationConfig } from '@angular/core';
import {provideRouter, withComponentInputBinding} from '@angular/router';

import { routes } from './app.routes';
import {HTTP_INTERCEPTORS, provideHttpClient, withInterceptorsFromDi} from "@angular/common/http";
import {environment} from "../environments/environment";
import {provideToastr} from "ngx-toastr";
import {provideAnimations} from "@angular/platform-browser/animations";
import {PlayerIdInterceptor} from "./shared/authorization/authorization-interceptor";
import {PlayerIdProvider} from "./shared/authorization/playerid-provider.service";

export abstract class ApiConfiguration {
  abstract readonly baseUrl: string;
}

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes, withComponentInputBinding()),
    provideHttpClient(withInterceptorsFromDi()),
    {provide: ApiConfiguration, useValue: environment},
    provideToastr(),
    provideAnimations(),
    {provide: PlayerIdProvider, useClass: PlayerIdProvider},
    {provide: HTTP_INTERCEPTORS, useClass: PlayerIdInterceptor, multi: true}
  ]

};

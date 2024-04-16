import {Injectable} from "@angular/core";
import {HttpHandler, HttpInterceptor, HttpRequest} from "@angular/common/http";
import {PlayerIdProvider} from "./playerid-provider.service";

@Injectable()
export class PlayerIdInterceptor implements HttpInterceptor {

  constructor(private readonly playerIdProvider: PlayerIdProvider) {}

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    // Get the auth token from the service.
    const playerId = this.playerIdProvider.get();

    console.log(playerId);

    // Clone the request and replace the original headers with
    // cloned headers, updated with the authorization.
    const authReq = req.clone({ setHeaders: { PlayerId: playerId } });

    // send cloned request with header to the next handler.
    return next.handle(authReq);
  }
}

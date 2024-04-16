import {Injectable} from "@angular/core";
import { v4 as uuidv4 } from 'uuid';

@Injectable({
  providedIn: 'root'
})
export class PlayerIdProvider {

  private storageKey: string = 'PlayerId';

  public get(): string {
    const playerId = localStorage.getItem(this.storageKey);

    if (!playerId) {
      const newPlayerId = uuidv4();
      localStorage.setItem(this.storageKey, newPlayerId)
      return newPlayerId;
    }

    return playerId;
  }
}

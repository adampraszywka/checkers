import {Injectable} from "@angular/core";

@Injectable()
export class LocalStorage {

  private readonly storage: Storage = localStorage

  public get(key: string): string|null {
    return this.storage.getItem(key);
  }

  public set(key: string, value: string): void {
    this.storage.setItem(key, value);
  }

  public remove(key: string): void {
    this.storage.removeItem(key);
  }

}

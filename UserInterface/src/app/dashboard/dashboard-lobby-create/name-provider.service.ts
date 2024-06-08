import {Injectable} from "@angular/core";
import { uniqueNamesGenerator, Config, adjectives, animals } from 'unique-names-generator';

@Injectable()
export class NameProvider {

  private readonly config: Config = {
    dictionaries: [adjectives, animals],
    separator: ' ',
    length: 2,
  };

  public get name(): string {
    return uniqueNamesGenerator(this.config);
  }
}

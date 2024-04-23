export interface ActionResult<T> {
  readonly value: T
  readonly errorMessage: string;
  readonly errorCode: string;
  readonly isSuccessful: boolean;
}

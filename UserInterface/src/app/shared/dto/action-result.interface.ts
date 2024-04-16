export interface ActionResult<T> {
  readonly value: T
  readonly errorMessage: string;
  readonly isSuccessful: boolean;
}

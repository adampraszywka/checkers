export class ModalResult {
  private readonly _value: string;
  private readonly _isFinalized: boolean;

  constructor(value: string|null) {

    if (value !== null) {
      this._value = value;
      this._isFinalized = true;
    } else {
      this._value = '';
      this._isFinalized = false;
    }
  }

  get isFinalized(): boolean {
    return this._isFinalized;
  }

  get value(): string {
    if (!this._isFinalized) {
      throw new Error()
    }
    return this._value;
  }
}

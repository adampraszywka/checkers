import { Component } from '@angular/core';
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {FormControl, ReactiveFormsModule} from "@angular/forms";

@Component({
  selector: 'app-dashboard-lobby-create',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './dashboard-lobby-create.component.html',
  styleUrl: './dashboard-lobby-create.component.scss'
})
export class DashboardLobbyCreateComponent {
  public name: FormControl<string>;
  constructor(public readonly modal: NgbActiveModal) {
    this.name = new FormControl<string>('', {nonNullable: true});
  }

  onCancel(): void {
    this.modal.close(new ModalResult(null));
  }

  onCreate(): void {
    const value = this.name.value;
    this.modal.close(new ModalResult(value));
  }
}

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

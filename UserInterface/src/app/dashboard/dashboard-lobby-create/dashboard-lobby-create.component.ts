import {Component, inject, signal} from '@angular/core';
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {FormControl, ReactiveFormsModule} from "@angular/forms";
import {ModalResult} from "../../shared/result/modal-result";
import {NameProvider} from "./name-provider.service";

@Component({
  selector: 'app-dashboard-lobby-create',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  providers: [
    NameProvider
  ],
  templateUrl: './dashboard-lobby-create.component.html',
  styleUrl: './dashboard-lobby-create.component.scss'
})
export class DashboardLobbyCreateComponent {
  private readonly modal = inject(NgbActiveModal);
  private readonly nameProvider = inject(NameProvider);

  nameFormControl: FormControl<string> = new FormControl<string>('', {nonNullable: true});
  placeholderName = signal<string>(this.nameProvider.name);

  onDismiss(): void {
    this.modal.dismiss();
  }

  onCancel(): void {
    this.modal.close(new ModalResult(null));
  }

  onCreate(): void {
    const userValue = this.nameFormControl.value;
    if (userValue.length > 0) {
      this.modal.close(new ModalResult(userValue));
    }

    this.modal.close(new ModalResult(this.placeholderName()));
  }
}


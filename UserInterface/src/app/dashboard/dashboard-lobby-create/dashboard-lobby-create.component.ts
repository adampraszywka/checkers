import {Component, inject} from '@angular/core';
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {FormControl, ReactiveFormsModule} from "@angular/forms";
import {ModalResult} from "../../shared/result/modal-result";

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
  private readonly modal = inject(NgbActiveModal);
  name: FormControl<string> = new FormControl<string>('', {nonNullable: true});


  onDismiss(): void {
    this.modal.dismiss();
  }

  onCancel(): void {
    this.modal.close(new ModalResult(null));
  }

  onCreate(): void {
    const value = this.name.value;
    this.modal.close(new ModalResult(value));
  }
}


import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {ApiClient} from "./api-client.service";
import {NgbProgressbar} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-slow-webapp',
  standalone: true,
  imports: [
    NgbProgressbar
  ],
  providers: [ApiClient],
  templateUrl: './slow-webapp.component.html',
  styleUrl: './slow-webapp.component.scss'
})
export class SlowWebappComponent implements OnInit {

  public progress: number = 0;
  private timer: number = -1;
  constructor(private readonly router: Router, private readonly client: ApiClient) {
  }
  ngOnInit(): void {
    this.startTimer();
    this.callPing();
  }

  private callPing(): void {
    this.client.ping().subscribe({
      next: x => {
        if (x.result === 'pong') {
          this.stopTimer();
          this.maxProgress();
          setTimeout(() => this.redirectToDashboard(), 500);
        } else {
          setTimeout(() => this.callPing(), 5000);
        }
      },
      error: _ => setTimeout(() => this.callPing(), 5000)
    })
  }

  private redirectToDashboard(): void {
    this.router.navigate(['/dashboard']).then();
  }

  private increaseProgress(): void {
    if (this.progress < 100) {
      this.progress++;
    } else {
      this.progress = 0;
    }
  }

  private maxProgress(): void {
    this.progress = 100;
  }

  private startTimer(): void {
    this.timer = setInterval(() => this.increaseProgress(), 500);
  }

  private stopTimer(): void {
    if (this.timer !== -1) {
      clearInterval(this.timer);
    }
  }
}

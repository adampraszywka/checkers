import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {BoardComponent} from "./board/board/board.component";
import {DashboardComponent} from "./dashboard/dashboard/dashboard.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, BoardComponent, DashboardComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'Smart Checkers!';
}

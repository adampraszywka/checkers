import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {BoardComponent} from "./board/board/board.component";
import {DashboardComponent} from "./dashboard/dashboard/dashboard.component";
import {SlowWebappComponent} from "./slow-webapp/slow-webapp.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, BoardComponent, DashboardComponent, SlowWebappComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'Smart Checkers!';
}

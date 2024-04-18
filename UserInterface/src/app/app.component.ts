import {Component, Inject, OnInit} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {BoardComponent} from "./board/board/board.component";
import {DashboardComponent} from "./dashboard/dashboard/dashboard.component";
import {SlowWebappComponent} from "./slow-webapp/slow-webapp.component";
import {DOCUMENT} from "@angular/common";
import {LocalStorage} from "./shared/storage/local-storage";
import {
  NgbDropdown,
  NgbDropdownItem,
  NgbDropdownMenu,
  NgbDropdownModule,
  NgbDropdownToggle
} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, BoardComponent, DashboardComponent, SlowWebappComponent, NgbDropdownModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  title = 'Smart Checkers!';

  private readonly themeKey: string = 'theme';

  constructor(@Inject(DOCUMENT) private readonly document: Document, private readonly storage: LocalStorage) {
  }

  ngOnInit(): void {
    const value = this.storage.get(this.themeKey);
    if (value !== null) {
      const theme = this.toTheme(value);
      this.setThemeAttribute(theme);
      return;
    }

    this.setThemeAttributeBasinOnSystemSettings();
  }

  public setTheme(theme: Theme) {
    this.storage.set(this.themeKey, theme);
    this.setThemeAttribute(theme);
  }

  public setDefaultTheme(): void {
    this.storage.remove(this.themeKey);
    this.setThemeAttributeBasinOnSystemSettings();
  }

  private setThemeAttributeBasinOnSystemSettings(): void {
    if (this.prefersDarkColorScheme()) {
      this.setThemeAttribute(Theme.Dark);
    } else {
      this.setThemeAttribute(Theme.Light);
    }
  }

  private prefersDarkColorScheme(): boolean {
    const window = this.document.defaultView;
    if (window !== null) {
      return window.matchMedia('(prefers-color-scheme: dark)').matches
    }

    return false;
  }

  private setThemeAttribute(theme: Theme): void {
    this.document.body.setAttribute('data-bs-theme', theme);
  }

  private toTheme(value: string): Theme {
    switch (value) {
      case Theme.Light.toString(): return Theme.Light;
      case Theme.Dark.toString(): return Theme.Dark;
      default: return Theme.Light;
    }
  }

  protected readonly Theme = Theme;
}

export enum Theme {
  Light = 'light', Dark = 'dark'
}

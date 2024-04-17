import { Routes } from '@angular/router';

export const routes: Routes = [
  {path: '', pathMatch: 'full', loadComponent: () => import('./slow-webapp/slow-webapp.component').then(mod => mod.SlowWebappComponent)},
  {path: 'dashboard', loadComponent: () => import('./dashboard/dashboard/dashboard.component').then(mod => mod.DashboardComponent)},
  {path: 'lobby/:lobbyId', loadComponent: () => import('./lobby/lobby/lobby.component').then(mod => mod.LobbyComponent)},
  {path: 'board/:boardId', loadComponent: () => import('./board/board/board.component').then(mod => mod.BoardComponent)}
];

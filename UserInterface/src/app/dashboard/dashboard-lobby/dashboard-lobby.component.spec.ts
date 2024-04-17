import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardLobbyComponent } from './dashboard-lobby.component';

describe('DashboardLobbyComponent', () => {
  let component: DashboardLobbyComponent;
  let fixture: ComponentFixture<DashboardLobbyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DashboardLobbyComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DashboardLobbyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  xit('should create', () => {
    expect(component).toBeTruthy();
  });
});

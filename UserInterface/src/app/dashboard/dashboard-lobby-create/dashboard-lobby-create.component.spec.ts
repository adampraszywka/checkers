import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardLobbyCreateComponent } from './dashboard-lobby-create.component';

describe('DashboardLobbyCreateComponent', () => {
  let component: DashboardLobbyCreateComponent;
  let fixture: ComponentFixture<DashboardLobbyCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DashboardLobbyCreateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DashboardLobbyCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  xit('should create', () => {
    expect(component).toBeTruthy();
  });
});

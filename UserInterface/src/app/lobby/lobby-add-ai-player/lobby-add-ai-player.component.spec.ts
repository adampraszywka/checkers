import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LobbyAddAiPlayerComponent } from './lobby-add-ai-player.component';

describe('LobbyAddAiPlayerComponent', () => {
  let component: LobbyAddAiPlayerComponent;
  let fixture: ComponentFixture<LobbyAddAiPlayerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LobbyAddAiPlayerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LobbyAddAiPlayerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  xit('should create', () => {
    expect(component).toBeTruthy();
  });
});

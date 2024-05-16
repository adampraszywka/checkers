import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MoveLogComponent } from './move-log.component';

describe('MoveLogComponent', () => {
  let component: MoveLogComponent;
  let fixture: ComponentFixture<MoveLogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MoveLogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MoveLogComponent);
    component = fixture.componentInstance;
    component.moveLog = [];
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

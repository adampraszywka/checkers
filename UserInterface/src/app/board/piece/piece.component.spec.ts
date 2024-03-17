import {ComponentFixture, TestBed} from '@angular/core/testing';

import {PieceComponent} from './piece.component';
import {Color, Type} from "../dto/piece.interface";

describe('PieceComponent', () => {
  let component: PieceComponent;
  let fixture: ComponentFixture<PieceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PieceComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PieceComponent);
    component = fixture.componentInstance;

    component.piece = {id: '', color: Color.Black, type: Type.Man};

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

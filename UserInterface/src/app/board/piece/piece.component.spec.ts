import {ComponentFixture, TestBed} from '@angular/core/testing';

import {PieceComponent} from './piece.component';
import {Color, Type} from "../dto/piece.interface";
import {By} from "@angular/platform-browser";

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

  it('white man', () => {
    component.piece = {id: '', color: Color.White, type: Type.Man};
    fixture.detectChanges();
    const classes = fixture.debugElement.query(By.css('div')).classes;

    expect(classes).toEqual({white: true, man: true})
  })

  it('white king', () => {
    component.piece = {id: '', color: Color.White, type: Type.King};
    fixture.detectChanges();
    const classes = fixture.debugElement.query(By.css('div')).classes;

    expect(classes).toEqual({white: true, king: true})
  })

  it('black man', () => {
    component.piece = {id: '', color: Color.Black, type: Type.Man};
    fixture.detectChanges();
    const classes = fixture.debugElement.query(By.css('div')).classes;

    expect(classes).toEqual({black: true, man: true})
  })

  it('black king', () => {
    component.piece = {id: '', color: Color.Black, type: Type.King};
    fixture.detectChanges();
    const classes = fixture.debugElement.query(By.css('div')).classes;

    expect(classes).toEqual({black: true, king: true})
  })
});

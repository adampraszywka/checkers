import {ComponentFixture, TestBed} from '@angular/core/testing';

import {PieceComponent} from './piece.component';
import {By} from "@angular/platform-browser";
import {Color, Type} from "../../shared/dto/piece.interface";
import {ComponentRef} from "@angular/core";

describe('PieceComponent', () => {
  let component: PieceComponent;
  let componentRef: ComponentRef<PieceComponent>;
  let fixture: ComponentFixture<PieceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PieceComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PieceComponent);
    component = fixture.componentInstance;
    componentRef = fixture.componentRef;

    componentRef.setInput('piece', {id: '', color: Color.Black, type: Type.Man})

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('white man', () => {
    componentRef.setInput('piece', {id: '', color: Color.White, type: Type.Man});
    fixture.detectChanges();
    const classes = fixture.debugElement.query(By.css('div')).classes;

    expect(classes).toEqual({white: true, man: true})
  })

  it('white king', () => {
    componentRef.setInput('piece', {id: '', color: Color.White, type: Type.King});
    fixture.detectChanges();
    const classes = fixture.debugElement.query(By.css('div')).classes;

    expect(classes).toEqual({white: true, king: true})
  })

  it('black man', () => {
    componentRef.setInput('piece', {id: '', color: Color.Black, type: Type.Man});
    fixture.detectChanges();
    const classes = fixture.debugElement.query(By.css('div')).classes;

    expect(classes).toEqual({black: true, man: true})
  })

  it('black king', () => {
    componentRef.setInput('piece', {id: '', color: Color.Black, type: Type.King});
    fixture.detectChanges();
    const classes = fixture.debugElement.query(By.css('div')).classes;

    expect(classes).toEqual({black: true, king: true})
  })
});

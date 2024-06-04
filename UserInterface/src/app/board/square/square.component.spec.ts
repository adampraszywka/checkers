import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SquareComponent } from './square.component';
import {By} from "@angular/platform-browser";
import {BoardService} from "../board/board.service";
import {HttpClientModule} from "@angular/common/http";
import {ApiConfiguration} from "../../app.config";
import {ComponentRef} from "@angular/core";

describe('SquareComponent', () => {
  let component: SquareComponent;
  let componentRef: ComponentRef<SquareComponent>;
  let fixture: ComponentFixture<SquareComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SquareComponent, HttpClientModule],
      providers: [BoardService, {provide: ApiConfiguration, useValue: {baseUrl: ''}}]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SquareComponent);
    component = fixture.componentInstance;
    componentRef = fixture.componentRef;
  });

  it('should create', () => {
    componentRef.setInput('square', {id: 'ID', piece: null, position: {row: 0, column: 0}})
    componentRef.setInput('row', 0);
    componentRef.setInput('column', 0);

    fixture.detectChanges();

    expect(component).toBeTruthy();
  });

  const squareColorCases = [
    {'row': 0, 'column': 0, 'expected': 'white'},
    {row: 0, column: 1, expected: 'black'}, {row: 0, column: 2, expected: 'white'}, {row: 0, column: 3, expected: 'black'},
    {row: 0, column: 4, expected: 'white'}, {row: 0, column: 5, expected: 'black'}, {row: 0, column: 6, expected: 'white'},
    {row: 0, column: 7, expected: 'black'}, {row: 1, column: 0, expected: 'black'}, {row: 1, column: 1, expected: 'white'},
    {row: 1, column: 2, expected: 'black'}, {row: 1, column: 3, expected: 'white'}, {row: 1, column: 4, expected: 'black'},
    {row: 1, column: 5, expected: 'white'}, {row: 1, column: 6, expected: 'black'}, {row: 1, column: 7, expected: 'white'},
    {row: 2, column: 0, expected: 'white'}, {row: 2, column: 1, expected: 'black'}, {row: 2, column: 2, expected: 'white'},
    {row: 2, column: 3, expected: 'black'}, {row: 2, column: 4, expected: 'white'}, {row: 2, column: 5, expected: 'black'},
    {row: 2, column: 6, expected: 'white'}, {row: 2, column: 7, expected: 'black'}, {row: 3, column: 0, expected: 'black'},
    {row: 3, column: 1, expected: 'white'}, {row: 3, column: 2, expected: 'black'}, {row: 3, column: 3, expected: 'white'},
    {row: 3, column: 4, expected: 'black'}, {row: 3, column: 5, expected: 'white'}, {row: 3, column: 6, expected: 'black'},
    {row: 3, column: 7, expected: 'white'}, {row: 4, column: 0, expected: 'white'}, {row: 4, column: 1, expected: 'black'},
    {row: 4, column: 2, expected: 'white'}, {row: 4, column: 3, expected: 'black'}, {row: 4, column: 4, expected: 'white'},
    {row: 4, column: 5, expected: 'black'}, {row: 4, column: 6, expected: 'white'}, {row: 4, column: 7, expected: 'black'},
    {row: 5, column: 0, expected: 'black'}, {row: 5, column: 1, expected: 'white'}, {row: 5, column: 2, expected: 'black'},
    {row: 5, column: 3, expected: 'white'}, {row: 5, column: 4, expected: 'black'}, {row: 5, column: 5, expected: 'white'},
    {row: 5, column: 6, expected: 'black'}, {row: 5, column: 7, expected: 'white'}, {row: 6, column: 0, expected: 'white'},
    {row: 6, column: 1, expected: 'black'}, {row: 6, column: 2, expected: 'white'}, {row: 6, column: 3, expected: 'black'},
    {row: 6, column: 4, expected: 'white'}, {row: 6, column: 5, expected: 'black'}, {row: 6, column: 6, expected: 'white'},
    {row: 6, column: 7, expected: 'black'}, {row: 7, column: 0, expected: 'black'}, {row: 7, column: 1, expected: 'white'},
    {row: 7, column: 2, expected: 'black'}, {row: 7, column: 3, expected: 'white'}, {row: 7, column: 4, expected: 'black'},
    {row: 7, column: 5, expected: 'white'}, {row: 7, column: 6, expected: 'black'}, {row: 7, column: 7, expected: 'white'}
  ]

  it.each(squareColorCases)('square background color', ({row, column, expected}) => {
    componentRef.setInput('square',{id: 'ID', piece: null, position: {row: 0, column: 0}});
    componentRef.setInput('row', row);
    componentRef.setInput('column', column);

    fixture.detectChanges();

    const element = fixture.debugElement.query(By.css('div')).nativeElement;
    expect(element.className).toContain(expected)
  })


});

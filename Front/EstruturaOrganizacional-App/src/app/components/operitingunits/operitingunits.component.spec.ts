/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { OperitingunitsComponent } from './operitingunits.component';

describe('OperitingunitsComponent', () => {
  let component: OperitingunitsComponent;
  let fixture: ComponentFixture<OperitingunitsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OperitingunitsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OperitingunitsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

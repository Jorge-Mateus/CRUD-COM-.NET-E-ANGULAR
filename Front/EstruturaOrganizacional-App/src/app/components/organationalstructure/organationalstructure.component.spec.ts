/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { OrganationalstructureComponent } from './organationalstructure.component';

describe('OrganationalstructureComponent', () => {
  let component: OrganationalstructureComponent;
  let fixture: ComponentFixture<OrganationalstructureComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OrganationalstructureComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OrganationalstructureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

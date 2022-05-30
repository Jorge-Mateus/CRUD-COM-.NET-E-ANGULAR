import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OperitingunitsaListaComponent } from './operitingunitsa-lista.component';

describe('OperitingunitsaListaComponent', () => {
  let component: OperitingunitsaListaComponent;
  let fixture: ComponentFixture<OperitingunitsaListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OperitingunitsaListaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OperitingunitsaListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

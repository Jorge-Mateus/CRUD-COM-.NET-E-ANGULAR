import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OperitingunitsDetalhesComponent } from './operitingunits-detalhes.component';

describe('OperitingunitsDetalhesComponent', () => {
  let component: OperitingunitsDetalhesComponent;
  let fixture: ComponentFixture<OperitingunitsDetalhesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OperitingunitsDetalhesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OperitingunitsDetalhesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

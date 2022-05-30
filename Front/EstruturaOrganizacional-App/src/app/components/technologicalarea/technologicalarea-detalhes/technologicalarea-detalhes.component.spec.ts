import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TechnologicalareaDetalhesComponent } from './technologicalarea-detalhes.component';

describe('TechnologicalareaDetalhesComponent', () => {
  let component: TechnologicalareaDetalhesComponent;
  let fixture: ComponentFixture<TechnologicalareaDetalhesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TechnologicalareaDetalhesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TechnologicalareaDetalhesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

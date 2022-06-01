import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrganationalstructureaDetalhesComponent } from './organationalstructurea-detalhes.component';

describe('OrganationalstructureaDetalhesComponent', () => {
  let component: OrganationalstructureaDetalhesComponent;
  let fixture: ComponentFixture<OrganationalstructureaDetalhesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrganationalstructureaDetalhesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrganationalstructureaDetalhesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

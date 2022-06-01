import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrganationalstructureaListaComponent } from './organationalstructurea-lista.component';

describe('OrganationalstructureaListaComponent', () => {
  let component: OrganationalstructureaListaComponent;
  let fixture: ComponentFixture<OrganationalstructureaListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrganationalstructureaListaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrganationalstructureaListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

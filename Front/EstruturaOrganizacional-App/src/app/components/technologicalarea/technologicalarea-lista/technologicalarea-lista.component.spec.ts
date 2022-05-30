import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TechnologicalareaListaComponent } from './technologicalarea-lista.component';

describe('TechnologicalareaListaComponent', () => {
  let component: TechnologicalareaListaComponent;
  let fixture: ComponentFixture<TechnologicalareaListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TechnologicalareaListaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TechnologicalareaListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

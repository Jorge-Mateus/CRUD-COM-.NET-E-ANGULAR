import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BusinessAreaListaComponent } from './business-area-lista.component';

describe('BusinessAreaListaComponent', () => {
  let component: BusinessAreaListaComponent;
  let fixture: ComponentFixture<BusinessAreaListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BusinessAreaListaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BusinessAreaListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BusinessAreaDetalhesComponent } from './business-area-detalhes.component';

describe('BusinessAreaDetalhesComponent', () => {
  let component: BusinessAreaDetalhesComponent;
  let fixture: ComponentFixture<BusinessAreaDetalhesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BusinessAreaDetalhesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BusinessAreaDetalhesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

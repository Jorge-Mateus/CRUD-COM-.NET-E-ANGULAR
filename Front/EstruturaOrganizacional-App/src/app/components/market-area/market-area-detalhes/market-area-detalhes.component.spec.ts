import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketAreaDetalhesComponent } from './market-area-detalhes.component';

describe('MarketAreaDetalhesComponent', () => {
  let component: MarketAreaDetalhesComponent;
  let fixture: ComponentFixture<MarketAreaDetalhesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MarketAreaDetalhesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MarketAreaDetalhesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketAreaListaComponent } from './market-area-lista.component';

describe('MarketAreaListaComponent', () => {
  let component: MarketAreaListaComponent;
  let fixture: ComponentFixture<MarketAreaListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MarketAreaListaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MarketAreaListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

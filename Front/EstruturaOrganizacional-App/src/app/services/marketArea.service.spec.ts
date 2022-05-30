/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MarketAreaService } from './marketArea.service';

describe('Service: MarketArea', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MarketAreaService]
    });
  });

  it('should ...', inject([MarketAreaService], (service: MarketAreaService) => {
    expect(service).toBeTruthy();
  }));
});

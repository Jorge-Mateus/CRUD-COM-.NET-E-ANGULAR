/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { OperitingUnitsService } from './operitingUnits.service';

describe('Service: OperitingUnits', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [OperitingUnitsService]
    });
  });

  it('should ...', inject([OperitingUnitsService], (service: OperitingUnitsService) => {
    expect(service).toBeTruthy();
  }));
});

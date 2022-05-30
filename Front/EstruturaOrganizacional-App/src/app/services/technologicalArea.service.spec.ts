/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TechnologicalAreaService } from './technologicalArea.service';

describe('Service: TechnologicalArea', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TechnologicalAreaService]
    });
  });

  it('should ...', inject([TechnologicalAreaService], (service: TechnologicalAreaService) => {
    expect(service).toBeTruthy();
  }));
});

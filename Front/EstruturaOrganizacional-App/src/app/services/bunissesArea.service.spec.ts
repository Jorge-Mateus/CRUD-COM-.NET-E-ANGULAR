/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { BunissesAreaService } from './bunissesArea.service';

describe('Service: BunissesArea', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BunissesAreaService]
    });
  });

  it('should ...', inject([BunissesAreaService], (service: BunissesAreaService) => {
    expect(service).toBeTruthy();
  }));
});

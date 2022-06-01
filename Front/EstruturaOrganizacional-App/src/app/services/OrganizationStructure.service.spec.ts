/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { OrganizationStructureService } from './OrganizationStructure.service';

describe('Service: OrganizationStructure', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [OrganizationStructureService]
    });
  });

  it('should ...', inject([OrganizationStructureService], (service: OrganizationStructureService) => {
    expect(service).toBeTruthy();
  }));
});

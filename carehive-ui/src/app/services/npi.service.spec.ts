import { TestBed } from '@angular/core/testing';

import { NpiService } from './npi.service';

describe('NpiService', () => {
  let service: NpiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NpiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

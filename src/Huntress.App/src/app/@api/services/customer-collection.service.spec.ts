import { TestBed } from '@angular/core/testing';

import { CustomerCollectionService } from './customer-collection.service';

describe('CustomerCollectionService', () => {
  let service: CustomerCollectionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CustomerCollectionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

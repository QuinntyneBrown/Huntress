import { TestBed } from '@angular/core/testing';

import { ProductCollectionService } from './product-collection.service';

describe('ProductCollectionService', () => {
  let service: ProductCollectionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductCollectionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

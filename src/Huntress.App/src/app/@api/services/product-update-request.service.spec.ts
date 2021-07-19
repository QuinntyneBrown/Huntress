import { TestBed } from '@angular/core/testing';

import { ProductUpdateRequestService } from './product-update-request.service';

describe('ProductUpdateRequestService', () => {
  let service: ProductUpdateRequestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductUpdateRequestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

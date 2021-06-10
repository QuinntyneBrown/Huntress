import { TestBed } from '@angular/core/testing';

import { CollectionItemService } from './collection-item.service';

describe('CollectionItemService', () => {
  let service: CollectionItemService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CollectionItemService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

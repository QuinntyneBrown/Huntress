import { TestBed } from '@angular/core/testing';

import { StoredEventService } from './stored-event.service';

describe('StoredEventService', () => {
  let service: StoredEventService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StoredEventService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

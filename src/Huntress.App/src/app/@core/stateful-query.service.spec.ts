import { TestBed } from '@angular/core/testing';

import { StatefulQueryService } from './stateful-query.service';

describe('StatefulQueryService', () => {
  let service: StatefulQueryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StatefulQueryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

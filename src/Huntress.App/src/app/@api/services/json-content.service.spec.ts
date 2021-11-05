import { TestBed } from '@angular/core/testing';

import { JsonContentService } from './json-content.service';

describe('JsonContentService', () => {
  let service: JsonContentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JsonContentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

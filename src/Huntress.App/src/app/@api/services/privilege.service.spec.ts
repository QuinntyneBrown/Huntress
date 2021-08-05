import { TestBed } from '@angular/core/testing';

import { PrivilegeService } from './privilege.service';

describe('PrivilegeService', () => {
  let service: PrivilegeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PrivilegeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { CssVariableService } from './css-variable.service';

describe('CssVariableService', () => {
  let service: CssVariableService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CssVariableService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

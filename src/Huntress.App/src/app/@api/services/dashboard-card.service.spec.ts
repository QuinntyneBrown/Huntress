import { TestBed } from '@angular/core/testing';

import { DashboardCardService } from './dashboard-card.service';

describe('DashboardCardService', () => {
  let service: DashboardCardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DashboardCardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

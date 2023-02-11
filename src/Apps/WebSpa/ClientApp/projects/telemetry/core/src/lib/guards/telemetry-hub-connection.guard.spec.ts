import { TestBed } from '@angular/core/testing';

import { TelemetryHubConnectionGuard } from './telemetry-hub-connection.guard';

describe('TelemetryHubConnectionGuard', () => {
  let guard: TelemetryHubConnectionGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(TelemetryHubConnectionGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});

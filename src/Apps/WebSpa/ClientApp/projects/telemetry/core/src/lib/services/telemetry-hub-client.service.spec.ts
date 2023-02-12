// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { TestBed } from '@angular/core/testing';

import { TelemetryHubClientService } from './telemetry-hub-client.service';

describe('TelemetryHubClientService', () => {
  let service: TelemetryHubClientService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TelemetryHubClientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

    // ARRANGE
    // ARRANGE



// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { TestBed } from '@angular/core/testing';

import { TelemetryStoreService } from './telemetry-store.service';

describe('TelemetryStoreService', () => {
  let service: TelemetryStoreService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TelemetryStoreService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

    // ARRANGE
    // ARRANGE



// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { TelemetryHubClientService } from './telemetry-hub-client.service';

@Injectable({
  providedIn: 'root'
})
export class TelemetryStoreService {

  constructor(
    private readonly _telemetryHubClientService: TelemetryHubClientService
  ) { }

  private _telemetry: any[] = [];

  public telemetry$: Observable<any[]> = this._telemetryHubClientService.telemetry$.pipe(

    map(messageAsString => {

      const message = JSON.parse(messageAsString);

      const messageBody = JSON.parse(message.Body);

      this._telemetry = [messageBody, ...this._telemetry];

      return this._telemetry;
    })
  )

  public connect() {
    return this._telemetryHubClientService.connect();
  }
}


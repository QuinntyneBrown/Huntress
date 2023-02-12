// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot } from '@angular/router';
import { TelemetryHubClientService } from '../services';
import { TelemetryStoreService } from '../services/telemetry-store.service';

@Injectable({
  providedIn: 'root'
})
export class TelemetryHubConnectionGuard implements CanActivate {

  constructor(
    private readonly _telemetryStoreService: TelemetryStoreService
  ) { }

  canActivate(
    route: ActivatedRouteSnapshot,state: RouterStateSnapshot): Promise<boolean> {
      return this._telemetryStoreService.connect();
  }  
}

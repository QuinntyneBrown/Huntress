// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { map } from 'rxjs';
import { TelemetryStoreService } from '../../services/telemetry-store.service';

@Component({
  selector: 'tl-telemetry',
  standalone: true,
  imports: [CommonModule],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './telemetry.component.html',
  styleUrls: ['./telemetry.component.scss']
})
export class TelemetryComponent {
  constructor(
    private readonly _telemtryStoreService: TelemetryStoreService
  ) { }

  public vm$ = this._telemtryStoreService.telemetry$.pipe(
    map(telemetry => {
      return {
        telemetry
      }
    })
  )
}


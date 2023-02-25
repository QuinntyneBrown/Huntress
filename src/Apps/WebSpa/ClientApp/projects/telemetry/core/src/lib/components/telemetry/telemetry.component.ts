// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { map } from 'rxjs';
import { TelemetryHubClientService } from '../../services';
import { PushModule } from '@ngrx/component';


@Component({
  selector: 'tl-telemetry',
  standalone: true,
  imports: [CommonModule, PushModule],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './telemetry.component.html',
  styleUrls: ['./telemetry.component.scss']
})
export class TelemetryComponent {
  
  private readonly _telemetryHubClientService = inject(TelemetryHubClientService);

  public vm$ = this._telemetryHubClientService.message$.pipe(
    map(message => {
      return {
        messages: [message]
      }
    })
  );
}



// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder, IHttpConnectionOptions } from '@microsoft/signalr';
import { from, Observable, shareReplay, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TelemetryHubClientService {
  static create(baseUrl:string): TelemetryHubClientService {
    const options: IHttpConnectionOptions = {                    
      logMessageContent: true               
    };

    var hubConnection = new HubConnectionBuilder()
    .withUrl(`${baseUrl}hub`, options)
    .withAutomaticReconnect()
    .build(); 

    return new TelemetryHubClientService(hubConnection);
  }

  constructor(private readonly _hubConnection: HubConnection) { }

  public message$ = new Subject<string>();

  public connect$(): Observable<void> {    
    this._hubConnection.on("message", (message:string) => {
      this.message$.next(message);
    });

    return from(this._hubConnection.start()).pipe(
      shareReplay(1)
    );
  }
}
// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Inject, Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder, IHttpConnectionOptions } from '@microsoft/signalr';
import { BASE_URL } from '../constants';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TelemetryHubClientService {

  private _hubConnection: HubConnection | undefined;

  private _connect: Promise<boolean> | undefined;
  
  public telemetry$ = new Subject<string>();

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl:string
  ) { }

  public connect(): Promise<boolean> {
    
    if(this._connect) return this._connect;

    this._connect = new Promise((resolve,reject) => {

      const options: IHttpConnectionOptions = {                    
        logMessageContent: true               
      };
  
      this._hubConnection = new HubConnectionBuilder()
      .withUrl(`${this._baseUrl}hub`, options)
      .build(); 
  
      this._hubConnection.on("telemetry", message => {
        this.telemetry$.next(message);
      });
  
      this._hubConnection.start();

      resolve(true);

    });

    return this._connect;
  }

  

}


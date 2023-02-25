// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { HubConnection } from '@microsoft/signalr';
import { TelemetryHubClientService } from './telemetry-hub-client.service';

export class MockHubConnection {
    
  public on(methodName:string, newMethod:{(...args:any[]):void}) {
      this.onCalled = true;
      return Promise.resolve();
  }

  public invoke(methodName:string, newMethod:{(...args:any[]):void}) {
    this.onCalled = true;
    return Promise.resolve();
  }

  public start() {
      this.startCalled = true;
      return Promise.resolve();
  }

  public onreconnected(callback:{(connectionId:string | undefined):void }) {

  }

  public startCalled = false;
  public onCalled = false;
  public invokeCalled = false;
  public onreconnectedCalled = false;
  
}

describe('TelemetryHubClientService', () => {
  let service: TelemetryHubClientService;
  let hubConnection: MockHubConnection = new MockHubConnection();

  beforeEach(() => {
    service = new TelemetryHubClientService(hubConnection as unknown as HubConnection);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should be call on and start', () => {
    service.connect$().subscribe();    
    expect(hubConnection.onCalled).toBeTruthy();
    expect(hubConnection.startCalled).toBeTruthy();
  });

});


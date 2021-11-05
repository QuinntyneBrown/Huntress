import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StoredEvent } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class StoredEventService implements IPagableService<StoredEvent> {

  uniqueIdentifierName: string = "storedEventId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<StoredEvent>> {
    return this._client.get<EntityPage<StoredEvent>>(`${this._baseUrl}api/storedEvent/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<StoredEvent[]> {
    return this._client.get<{ storedEvents: StoredEvent[] }>(`${this._baseUrl}api/storedEvent`)
      .pipe(
        map(x => x.storedEvents)
      );
  }

  public getById(options: { storedEventId: string }): Observable<StoredEvent> {
    return this._client.get<{ storedEvent: StoredEvent }>(`${this._baseUrl}api/storedEvent/${options.storedEventId}`)
      .pipe(
        map(x => x.storedEvent)
      );
  }

  public remove(options: { storedEvent: StoredEvent }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/storedEvent/${options.storedEvent.storedEventId}`);
  }

  public create(options: { storedEvent: StoredEvent }): Observable<{ storedEvent: StoredEvent }> {
    return this._client.post<{ storedEvent: StoredEvent }>(`${this._baseUrl}api/storedEvent`, { storedEvent: options.storedEvent });
  }
  
  public update(options: { storedEvent: StoredEvent }): Observable<{ storedEvent: StoredEvent }> {
    return this._client.put<{ storedEvent: StoredEvent }>(`${this._baseUrl}api/storedEvent`, { storedEvent: options.storedEvent });
  }
}

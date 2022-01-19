import { Injectable, Inject } from '@angular/core';
import { BASE_URL } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Collection } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class CollectionService implements IPagableService<Collection> {

  uniqueIdentifierName: string = "collectionId";

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Collection>> {
    return this._client.get<EntityPage<Collection>>(`${this._baseUrl}api/collection/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Collection[]> {
    return this._client.get<{ collections: Collection[] }>(`${this._baseUrl}api/collection`)
      .pipe(
        map(x => x.collections)
      );
  }

  public getById(options: { collectionId: string }): Observable<Collection> {
    return this._client.get<{ collection: Collection }>(`${this._baseUrl}api/collection/${options.collectionId}`)
      .pipe(
        map(x => x.collection)
      );
  }

  public remove(options: { collection: Collection }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/collection/${options.collection.collectionId}`);
  }

  public create(options: { collection: Collection }): Observable<{ collection: Collection }> {
    return this._client.post<{ collection: Collection }>(`${this._baseUrl}api/collection`, { collection: options.collection });
  }
  
  public update(options: { collection: Collection }): Observable<{ collection: Collection }> {
    return this._client.put<{ collection: Collection }>(`${this._baseUrl}api/collection`, { collection: options.collection });
  }
}

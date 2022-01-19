import { Injectable, Inject } from '@angular/core';
import { BASE_URL } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { CollectionItem } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class CollectionItemService implements IPagableService<CollectionItem> {

  uniqueIdentifierName: string = "collectionItemId";

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<CollectionItem>> {
    return this._client.get<EntityPage<CollectionItem>>(`${this._baseUrl}api/collectionItem/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<CollectionItem[]> {
    return this._client.get<{ collectionItems: CollectionItem[] }>(`${this._baseUrl}api/collectionItem`)
      .pipe(
        map(x => x.collectionItems)
      );
  }

  public getById(options: { collectionItemId: string }): Observable<CollectionItem> {
    return this._client.get<{ collectionItem: CollectionItem }>(`${this._baseUrl}api/collectionItem/${options.collectionItemId}`)
      .pipe(
        map(x => x.collectionItem)
      );
  }

  public remove(options: { collectionItem: CollectionItem }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/collectionItem/${options.collectionItem.collectionItemId}`);
  }

  public create(options: { collectionItem: CollectionItem }): Observable<{ collectionItem: CollectionItem }> {
    return this._client.post<{ collectionItem: CollectionItem }>(`${this._baseUrl}api/collectionItem`, { collectionItem: options.collectionItem });
  }
  
  public update(options: { collectionItem: CollectionItem }): Observable<{ collectionItem: CollectionItem }> {
    return this._client.put<{ collectionItem: CollectionItem }>(`${this._baseUrl}api/collectionItem`, { collectionItem: options.collectionItem });
  }
}

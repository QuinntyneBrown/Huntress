import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { InstagramFeedItem } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class InstagramFeedItemService implements IPagableService<InstagramFeedItem> {

  uniqueIdentifierName: string = "instagramFeedItemId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<InstagramFeedItem>> {
    return this._client.get<EntityPage<InstagramFeedItem>>(`${this._baseUrl}api/instagramFeedItem/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<InstagramFeedItem[]> {
    return this._client.get<{ instagramFeedItems: InstagramFeedItem[] }>(`${this._baseUrl}api/instagramFeedItem`)
      .pipe(
        map(x => x.instagramFeedItems)
      );
  }

  public getById(options: { instagramFeedItemId: string }): Observable<InstagramFeedItem> {
    return this._client.get<{ instagramFeedItem: InstagramFeedItem }>(`${this._baseUrl}api/instagramFeedItem/${options.instagramFeedItemId}`)
      .pipe(
        map(x => x.instagramFeedItem)
      );
  }

  public remove(options: { instagramFeedItem: InstagramFeedItem }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/instagramFeedItem/${options.instagramFeedItem.instagramFeedItemId}`);
  }

  public create(options: { instagramFeedItem: InstagramFeedItem }): Observable<{ instagramFeedItem: InstagramFeedItem }> {
    return this._client.post<{ instagramFeedItem: InstagramFeedItem }>(`${this._baseUrl}api/instagramFeedItem`, { instagramFeedItem: options.instagramFeedItem });
  }
  
  public update(options: { instagramFeedItem: InstagramFeedItem }): Observable<{ instagramFeedItem: InstagramFeedItem }> {
    return this._client.put<{ instagramFeedItem: InstagramFeedItem }>(`${this._baseUrl}api/instagramFeedItem`, { instagramFeedItem: options.instagramFeedItem });
  }
}

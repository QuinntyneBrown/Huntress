import { Injectable, Inject } from '@angular/core';
import { BASE_URL } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { InstagramFeed } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class InstagramFeedService implements IPagableService<InstagramFeed> {

  uniqueIdentifierName: string = "instagramFeedId";

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<InstagramFeed>> {
    return this._client.get<EntityPage<InstagramFeed>>(`${this._baseUrl}api/instagramFeed/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<InstagramFeed[]> {
    return this._client.get<{ instagramFeeds: InstagramFeed[] }>(`${this._baseUrl}api/instagramFeed`)
      .pipe(
        map(x => x.instagramFeeds)
      );
  }

  public getById(options: { instagramFeedId: string }): Observable<InstagramFeed> {
    return this._client.get<{ instagramFeed: InstagramFeed }>(`${this._baseUrl}api/instagramFeed/${options.instagramFeedId}`)
      .pipe(
        map(x => x.instagramFeed)
      );
  }

  public remove(options: { instagramFeed: InstagramFeed }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/instagramFeed/${options.instagramFeed.instagramFeedId}`);
  }

  public create(options: { instagramFeed: InstagramFeed }): Observable<{ instagramFeed: InstagramFeed }> {
    return this._client.post<{ instagramFeed: InstagramFeed }>(`${this._baseUrl}api/instagramFeed`, { instagramFeed: options.instagramFeed });
  }
  
  public update(options: { instagramFeed: InstagramFeed }): Observable<{ instagramFeed: InstagramFeed }> {
    return this._client.put<{ instagramFeed: InstagramFeed }>(`${this._baseUrl}api/instagramFeed`, { instagramFeed: options.instagramFeed });
  }
}

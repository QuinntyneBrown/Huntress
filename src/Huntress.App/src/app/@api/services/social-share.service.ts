import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { SocialShare } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class SocialShareService implements IPagableService<SocialShare> {

  uniqueIdentifierName: string = "socialShareId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<SocialShare>> {
    return this._client.get<EntityPage<SocialShare>>(`${this._baseUrl}api/socialShare/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<SocialShare[]> {
    return this._client.get<{ socialShares: SocialShare[] }>(`${this._baseUrl}api/socialShare`)
      .pipe(
        map(x => x.socialShares)
      );
  }

  public getById(options: { socialShareId: string }): Observable<SocialShare> {
    return this._client.get<{ socialShare: SocialShare }>(`${this._baseUrl}api/socialShare/${options.socialShareId}`)
      .pipe(
        map(x => x.socialShare)
      );
  }

  public remove(options: { socialShare: SocialShare }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/socialShare/${options.socialShare.socialShareId}`);
  }

  public create(options: { socialShare: SocialShare }): Observable<{ socialShare: SocialShare }> {
    return this._client.post<{ socialShare: SocialShare }>(`${this._baseUrl}api/socialShare`, { socialShare: options.socialShare });
  }
  
  public update(options: { socialShare: SocialShare }): Observable<{ socialShare: SocialShare }> {
    return this._client.put<{ socialShare: SocialShare }>(`${this._baseUrl}api/socialShare`, { socialShare: options.socialShare });
  }
}

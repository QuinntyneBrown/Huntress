import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { HtmlContent } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';
import { HtmlContentType } from '@api/models/html-content-type';

@Injectable({
  providedIn: 'root'
})
export class HtmlContentService implements IPagableService<HtmlContent> {

  uniqueIdentifierName: string = "htmlContentId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<HtmlContent>> {
    return this._client.get<EntityPage<HtmlContent>>(`${this._baseUrl}api/htmlContent/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<HtmlContent[]> {
    return this._client.get<{ htmlContents: HtmlContent[] }>(`${this._baseUrl}api/htmlContent`)
      .pipe(
        map(x => x.htmlContents)
      );
  }

  public getById(options: { htmlContentId: string }): Observable<HtmlContent> {
    return this._client.get<{ htmlContent: HtmlContent }>(`${this._baseUrl}api/htmlContent/${options.htmlContentId}`)
      .pipe(
        map(x => x.htmlContent)
      );
  }

  public getByType(options: { htmlContentType: HtmlContentType }): Observable<HtmlContent> {
    return this._client.get<{ htmlContent: HtmlContent }>(`${this._baseUrl}api/htmlContent/type/${options.htmlContentType}`)
      .pipe(
        map(x => x.htmlContent)
      );
  }

  public remove(options: { htmlContent: HtmlContent }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/htmlContent/${options.htmlContent.htmlContentId}`);
  }

  public create(options: { htmlContent: HtmlContent }): Observable<{ htmlContent: HtmlContent }> {
    return this._client.post<{ htmlContent: HtmlContent }>(`${this._baseUrl}api/htmlContent`, { htmlContent: options.htmlContent });
  }

  public update(options: { htmlContent: HtmlContent }): Observable<{ htmlContent: HtmlContent }> {
    return this._client.put<{ htmlContent: HtmlContent }>(`${this._baseUrl}api/htmlContent`, { htmlContent: options.htmlContent });
  }
}

import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JsonContent } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class JsonContentService implements IPagableService<JsonContent> {

  uniqueIdentifierName: string = "jsonContentId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<JsonContent>> {
    return this._client.get<EntityPage<JsonContent>>(`${this._baseUrl}api/jsonContent/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<JsonContent[]> {
    return this._client.get<{ jsonContents: JsonContent[] }>(`${this._baseUrl}api/jsonContent`)
      .pipe(
        map(x => x.jsonContents)
      );
  }

  public getById(options: { jsonContentId: string }): Observable<JsonContent> {
    return this._client.get<{ jsonContent: JsonContent }>(`${this._baseUrl}api/jsonContent/${options.jsonContentId}`)
      .pipe(
        map(x => x.jsonContent)
      );
  }

  public remove(options: { jsonContent: JsonContent }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/jsonContent/${options.jsonContent.jsonContentId}`);
  }

  public create(options: { jsonContent: JsonContent }): Observable<{ jsonContent: JsonContent }> {
    return this._client.post<{ jsonContent: JsonContent }>(`${this._baseUrl}api/jsonContent`, { jsonContent: options.jsonContent });
  }
  
  public update(options: { jsonContent: JsonContent }): Observable<{ jsonContent: JsonContent }> {
    return this._client.put<{ jsonContent: JsonContent }>(`${this._baseUrl}api/jsonContent`, { jsonContent: options.jsonContent });
  }
}

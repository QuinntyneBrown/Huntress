import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Content } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { BASE_URL } from '@core';

@Injectable({
  providedIn: 'root'
})
export class ContentService {

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  public get(): Observable<Content[]> {
    return this._client.get<{ contents: Content[] }>(`${this._baseUrl}api/content`)
      .pipe(
        map(x => x.contents)
      );
  }

  public getById(options: { contentId: string }): Observable<Content> {
    return this._client.get<{ content: Content }>(`${this._baseUrl}api/content/${options.contentId}`)
      .pipe(
        map(x => x.content)
      );
  }

  public getByName(options: { name: string }): Observable<Content> {
    return this._client.get<{ content: Content }>(`${this._baseUrl}api/content/name/${options.name}`)
      .pipe(
        map(x => x.content)
      );
  }
  public remove(options: { content: Content }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/content/${options.content.contentId}`);
  }

  public create(options: { content: Content }): Observable<{ content: Content }> {
    return this._client.post<{ content: Content }>(`${this._baseUrl}api/content`, { content: options.content });
  }

  public update(options: { content: Content }): Observable<{ content: Content }> {
    return this._client.put<{ content: Content }>(`${this._baseUrl}api/content`, { content: options.content });
  }
}

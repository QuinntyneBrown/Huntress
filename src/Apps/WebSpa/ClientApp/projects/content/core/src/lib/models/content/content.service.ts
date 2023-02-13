// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BASE_URL } from '../../constants';
import { map, Observable } from 'rxjs';
import { Content } from './content';

@Injectable({
  providedIn: 'root'
})
export class ContentService {

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  public get(): Observable<Array<Content>> {
    return this._client.get<{ contents: Array<Content> }>(`${this._baseUrl}api/content`)
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

  public delete(options: { content: Content }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/content/${options.content.contentId}`);
  }

  public create(options: { content: Content }): Observable<{ contentId: string  }> {    
    return this._client.post<{ contentId: string }>(`${this._baseUrl}api/content`, { content: options.content });
  }

  public update(options: { content: Content }): Observable<{ contentId: string }> {    
    return this._client.post<{ contentId: string }>(`${this._baseUrl}api/content`, { content: options.content });
  }
}

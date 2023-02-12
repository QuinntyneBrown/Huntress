// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BASE_URL } from '../../constants';
import { map, Observable } from 'rxjs';
import { CardLayout } from './card-layout';

@Injectable({
  providedIn: 'root'
})
export class CardLayoutService {

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  public get(): Observable<Array<CardLayout>> {
    return this._client.get<{ cardLayouts: Array<CardLayout> }>(`${this._baseUrl}api/card-layout`)
      .pipe(
        map(x => x.cardLayouts)
      );
  }

  public getById(options: { cardLayoutId: string }): Observable<CardLayout> {
    return this._client.get<{ cardLayout: CardLayout }>(`${this._baseUrl}api/card-layout/${options.cardLayoutId}`)
      .pipe(
        map(x => x.cardLayout)
      );
  }

  public delete(options: { cardLayout: CardLayout }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/card-layout/${options.cardLayout.cardLayoutId}`);
  }

  public create(options: { cardLayout: CardLayout }): Observable<{ cardLayoutId: string  }> {    
    return this._client.post<{ cardLayoutId: string }>(`${this._baseUrl}api/card-layout`, { cardLayout: options.cardLayout });
  }

  public update(options: { cardLayout: CardLayout }): Observable<{ cardLayoutId: string }> {    
    return this._client.post<{ cardLayoutId: string }>(`${this._baseUrl}api/card-layout`, { cardLayout: options.cardLayout });
  }
}

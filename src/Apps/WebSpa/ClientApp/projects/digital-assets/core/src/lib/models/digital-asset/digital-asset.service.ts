// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BASE_URL } from '../../constants';
import { map, Observable } from 'rxjs';
import { DigitalAsset } from './digital-asset';

@Injectable({
  providedIn: 'root'
})
export class DigitalAssetService {

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  public get(): Observable<Array<DigitalAsset>> {
    return this._client.get<{ digitalAssets: Array<DigitalAsset> }>(`${this._baseUrl}api/digital-asset`)
      .pipe(
        map(x => x.digitalAssets)
      );
  }

  public getById(options: { digitalAssetId: string }): Observable<DigitalAsset> {
    return this._client.get<{ digitalAsset: DigitalAsset }>(`${this._baseUrl}api/digital-asset/${options.digitalAssetId}`)
      .pipe(
        map(x => x.digitalAsset)
      );
  }

  public delete(options: { digitalAsset: DigitalAsset }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/digital-asset/${options.digitalAsset.digitalAssetId}`);
  }

  public create(options: { digitalAsset: DigitalAsset }): Observable<{ digitalAssetId: string  }> {    
    return this._client.post<{ digitalAssetId: string }>(`${this._baseUrl}api/digital-asset`, { digitalAsset: options.digitalAsset });
  }

  public update(options: { digitalAsset: DigitalAsset }): Observable<{ digitalAssetId: string }> {    
    return this._client.post<{ digitalAssetId: string }>(`${this._baseUrl}api/digital-asset`, { digitalAsset: options.digitalAsset });
  }
}

// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BASE_URL } from '../../constants';
import { map, Observable } from 'rxjs';
import { Privilege } from './privilege';

@Injectable({
  providedIn: 'root'
})
export class PrivilegeService {

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  public get(): Observable<Array<Privilege>> {
    return this._client.get<{ privileges: Array<Privilege> }>(`${this._baseUrl}api/privilege`)
      .pipe(
        map(x => x.privileges)
      );
  }

  public getById(options: { privilegeId: string }): Observable<Privilege> {
    return this._client.get<{ privilege: Privilege }>(`${this._baseUrl}api/privilege/${options.privilegeId}`)
      .pipe(
        map(x => x.privilege)
      );
  }

  public delete(options: { privilege: Privilege }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/privilege/${options.privilege.privilegeId}`);
  }

  public create(options: { privilege: Privilege }): Observable<{ privilegeId: string  }> {    
    return this._client.post<{ privilegeId: string }>(`${this._baseUrl}api/privilege`, { privilege: options.privilege });
  }

  public update(options: { privilege: Privilege }): Observable<{ privilegeId: string }> {    
    return this._client.post<{ privilegeId: string }>(`${this._baseUrl}api/privilege`, { privilege: options.privilege });
  }
}

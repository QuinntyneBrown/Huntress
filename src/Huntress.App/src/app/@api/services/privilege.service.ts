import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Privilege } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class PrivilegeService implements IPagableService<Privilege> {

  uniqueIdentifierName: string = "privilegeId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Privilege>> {
    return this._client.get<EntityPage<Privilege>>(`${this._baseUrl}api/privilege/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Privilege[]> {
    return this._client.get<{ privileges: Privilege[] }>(`${this._baseUrl}api/privilege`)
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

  public remove(options: { privilege: Privilege }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/privilege/${options.privilege.privilegeId}`);
  }

  public create(options: { privilege: Privilege }): Observable<{ privilege: Privilege }> {
    return this._client.post<{ privilege: Privilege }>(`${this._baseUrl}api/privilege`, { privilege: options.privilege });
  }
  
  public update(options: { privilege: Privilege }): Observable<{ privilege: Privilege }> {
    return this._client.put<{ privilege: Privilege }>(`${this._baseUrl}api/privilege`, { privilege: options.privilege });
  }
}

import { Injectable, Inject } from '@angular/core';
import { BASE_URL } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { CssVariable } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class CssVariableService implements IPagableService<CssVariable> {

  uniqueIdentifierName: string = "cssVariableId";

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<CssVariable>> {
    return this._client.get<EntityPage<CssVariable>>(`${this._baseUrl}api/cssVariable/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<CssVariable[]> {
    return this._client.get<{ cssVariables: CssVariable[] }>(`${this._baseUrl}api/cssVariable`)
      .pipe(
        map(x => x.cssVariables)
      );
  }

  public getById(options: { cssVariableId: string }): Observable<CssVariable> {
    return this._client.get<{ cssVariable: CssVariable }>(`${this._baseUrl}api/cssVariable/${options.cssVariableId}`)
      .pipe(
        map(x => x.cssVariable)
      );
  }

  public remove(options: { cssVariable: CssVariable }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/cssVariable/${options.cssVariable.cssVariableId}`);
  }

  public create(options: { cssVariable: CssVariable }): Observable<{ cssVariable: CssVariable }> {
    return this._client.post<{ cssVariable: CssVariable }>(`${this._baseUrl}api/cssVariable`, { cssVariable: options.cssVariable });
  }
  
  public update(options: { cssVariable: CssVariable }): Observable<{ cssVariable: CssVariable }> {
    return this._client.put<{ cssVariable: CssVariable }>(`${this._baseUrl}api/cssVariable`, { cssVariable: options.cssVariable });
  }
}

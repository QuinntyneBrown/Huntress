import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Theme } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class ThemeService implements IPagableService<Theme> {

  uniqueIdentifierName: string = "themeId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Theme>> {
    return this._client.get<EntityPage<Theme>>(`${this._baseUrl}api/theme/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Theme[]> {
    return this._client.get<{ themes: Theme[] }>(`${this._baseUrl}api/theme`)
      .pipe(
        map(x => x.themes)
      );
  }

  public getById(options: { themeId: string }): Observable<Theme> {
    return this._client.get<{ theme: Theme }>(`${this._baseUrl}api/theme/${options.themeId}`)
      .pipe(
        map(x => x.theme)
      );
  }

  public remove(options: { theme: Theme }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/theme/${options.theme.themeId}`);
  }

  public create(options: { theme: Theme }): Observable<{ theme: Theme }> {
    return this._client.post<{ theme: Theme }>(`${this._baseUrl}api/theme`, { theme: options.theme });
  }
  
  public update(options: { theme: Theme }): Observable<{ theme: Theme }> {
    return this._client.put<{ theme: Theme }>(`${this._baseUrl}api/theme`, { theme: options.theme });
  }
}

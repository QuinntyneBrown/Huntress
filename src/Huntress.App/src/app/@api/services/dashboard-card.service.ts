import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DashboardCard } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class DashboardCardService implements IPagableService<DashboardCard> {

  uniqueIdentifierName: string = "dashboardCardId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<DashboardCard>> {
    return this._client.get<EntityPage<DashboardCard>>(`${this._baseUrl}api/dashboardCard/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<DashboardCard[]> {
    return this._client.get<{ dashboardCards: DashboardCard[] }>(`${this._baseUrl}api/dashboardCard`)
      .pipe(
        map(x => x.dashboardCards)
      );
  }

  public getById(options: { dashboardCardId: string }): Observable<DashboardCard> {
    return this._client.get<{ dashboardCard: DashboardCard }>(`${this._baseUrl}api/dashboardCard/${options.dashboardCardId}`)
      .pipe(
        map(x => x.dashboardCard)
      );
  }

  public remove(options: { dashboardCard: DashboardCard }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/dashboardCard/${options.dashboardCard.dashboardCardId}`);
  }

  public create(options: { dashboardCard: DashboardCard }): Observable<{ dashboardCard: DashboardCard }> {
    return this._client.post<{ dashboardCard: DashboardCard }>(`${this._baseUrl}api/dashboardCard`, { dashboardCard: options.dashboardCard });
  }
  
  public update(options: { dashboardCard: DashboardCard }): Observable<{ dashboardCard: DashboardCard }> {
    return this._client.put<{ dashboardCard: DashboardCard }>(`${this._baseUrl}api/dashboardCard`, { dashboardCard: options.dashboardCard });
  }
}

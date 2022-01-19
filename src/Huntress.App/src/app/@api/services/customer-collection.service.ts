import { Injectable, Inject } from '@angular/core';
import { BASE_URL } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { CustomerCollection } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class CustomerCollectionService implements IPagableService<CustomerCollection> {

  uniqueIdentifierName: string = "customerCollectionId";

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<CustomerCollection>> {
    return this._client.get<EntityPage<CustomerCollection>>(`${this._baseUrl}api/customerCollection/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<CustomerCollection[]> {
    return this._client.get<{ customerCollections: CustomerCollection[] }>(`${this._baseUrl}api/customerCollection`)
      .pipe(
        map(x => x.customerCollections)
      );
  }

  public getById(options: { customerCollectionId: string }): Observable<CustomerCollection> {
    return this._client.get<{ customerCollection: CustomerCollection }>(`${this._baseUrl}api/customerCollection/${options.customerCollectionId}`)
      .pipe(
        map(x => x.customerCollection)
      );
  }

  public remove(options: { customerCollection: CustomerCollection }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/customerCollection/${options.customerCollection.customerCollectionId}`);
  }

  public create(options: { customerCollection: CustomerCollection }): Observable<{ customerCollection: CustomerCollection }> {
    return this._client.post<{ customerCollection: CustomerCollection }>(`${this._baseUrl}api/customerCollection`, { customerCollection: options.customerCollection });
  }
  
  public update(options: { customerCollection: CustomerCollection }): Observable<{ customerCollection: CustomerCollection }> {
    return this._client.put<{ customerCollection: CustomerCollection }>(`${this._baseUrl}api/customerCollection`, { customerCollection: options.customerCollection });
  }
}

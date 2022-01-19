import { Injectable, Inject } from '@angular/core';
import { BASE_URL } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { ProductCollection } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class ProductCollectionService implements IPagableService<ProductCollection> {

  uniqueIdentifierName: string = "productCollectionId";

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<ProductCollection>> {
    return this._client.get<EntityPage<ProductCollection>>(`${this._baseUrl}api/productCollection/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<ProductCollection[]> {
    return this._client.get<{ productCollections: ProductCollection[] }>(`${this._baseUrl}api/productCollection`)
      .pipe(
        map(x => x.productCollections)
      );
  }

  public getById(options: { productCollectionId: string }): Observable<ProductCollection> {
    return this._client.get<{ productCollection: ProductCollection }>(`${this._baseUrl}api/productCollection/${options.productCollectionId}`)
      .pipe(
        map(x => x.productCollection)
      );
  }

  public remove(options: { productCollection: ProductCollection }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/productCollection/${options.productCollection.productCollectionId}`);
  }

  public create(options: { productCollection: ProductCollection }): Observable<{ productCollection: ProductCollection }> {
    return this._client.post<{ productCollection: ProductCollection }>(`${this._baseUrl}api/productCollection`, { productCollection: options.productCollection });
  }
  
  public update(options: { productCollection: ProductCollection }): Observable<{ productCollection: ProductCollection }> {
    return this._client.put<{ productCollection: ProductCollection }>(`${this._baseUrl}api/productCollection`, { productCollection: options.productCollection });
  }
}

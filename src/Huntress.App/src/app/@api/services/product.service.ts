import { Injectable, Inject } from '@angular/core';
import { BASE_URL } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Product } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class ProductService implements IPagableService<Product> {

  uniqueIdentifierName: string = "productId";

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Product>> {
    return this._client.get<EntityPage<Product>>(`${this._baseUrl}api/product/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Product[]> {
    return this._client.get<{ products: Product[] }>(`${this._baseUrl}api/product`)
      .pipe(
        map(x => x.products)
      );
  }

  public getById(options: { productId: string }): Observable<Product> {
    return this._client.get<{ product: Product }>(`${this._baseUrl}api/product/${options.productId}`)
      .pipe(
        map(x => x.product)
      );
  }

  public getByName(options: { name: string }): Observable<Product> {
    return this._client.get<{ product: Product }>(`${this._baseUrl}api/product/name/${options.name}`)
      .pipe(
        map(x => x.product)
      );
  }


  public remove(options: { product: Product }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/product/${options.product.productId}`);
  }

  public create(options: { product: Product }): Observable<{ product: Product }> {
    return this._client.post<{ product: Product }>(`${this._baseUrl}api/product`, { product: options.product });
  }

  public update(options: { product: Product }): Observable<{ product: Product }> {
    return this._client.put<{ product: Product }>(`${this._baseUrl}api/product`, { product: options.product });
  }
}

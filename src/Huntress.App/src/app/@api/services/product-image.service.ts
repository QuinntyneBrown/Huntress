import { Injectable, Inject } from '@angular/core';
import { BASE_URL } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { ProductImage } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class ProductImageService implements IPagableService<ProductImage> {

  uniqueIdentifierName: string = "productImageId";

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<ProductImage>> {
    return this._client.get<EntityPage<ProductImage>>(`${this._baseUrl}api/productImage/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<ProductImage[]> {
    return this._client.get<{ productImages: ProductImage[] }>(`${this._baseUrl}api/productImage`)
      .pipe(
        map(x => x.productImages)
      );
  }

  public getById(options: { productImageId: string }): Observable<ProductImage> {
    return this._client.get<{ productImage: ProductImage }>(`${this._baseUrl}api/productImage/${options.productImageId}`)
      .pipe(
        map(x => x.productImage)
      );
  }

  public remove(options: { productImage: ProductImage }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/productImage/${options.productImage.productImageId}`);
  }

  public create(options: { productImage: ProductImage }): Observable<{ productImage: ProductImage }> {
    return this._client.post<{ productImage: ProductImage }>(`${this._baseUrl}api/productImage`, { productImage: options.productImage });
  }
  
  public update(options: { productImage: ProductImage }): Observable<{ productImage: ProductImage }> {
    return this._client.put<{ productImage: ProductImage }>(`${this._baseUrl}api/productImage`, { productImage: options.productImage });
  }
}

import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { ProductUpdateRequest } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class ProductUpdateRequestService implements IPagableService<ProductUpdateRequest> {

  uniqueIdentifierName: string = "productUpdateRequestId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<ProductUpdateRequest>> {
    return this._client.get<EntityPage<ProductUpdateRequest>>(`${this._baseUrl}api/productUpdateRequest/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<ProductUpdateRequest[]> {
    return this._client.get<{ productUpdateRequests: ProductUpdateRequest[] }>(`${this._baseUrl}api/productUpdateRequest`)
      .pipe(
        map(x => x.productUpdateRequests)
      );
  }

  public getById(options: { productUpdateRequestId: string }): Observable<ProductUpdateRequest> {
    return this._client.get<{ productUpdateRequest: ProductUpdateRequest }>(`${this._baseUrl}api/productUpdateRequest/${options.productUpdateRequestId}`)
      .pipe(
        map(x => x.productUpdateRequest)
      );
  }

  public remove(options: { productUpdateRequest: ProductUpdateRequest }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/productUpdateRequest/${options.productUpdateRequest.productUpdateRequestId}`);
  }

  public create(options: { productUpdateRequest: ProductUpdateRequest }): Observable<{ productUpdateRequest: ProductUpdateRequest }> {
    return this._client.post<{ productUpdateRequest: ProductUpdateRequest }>(`${this._baseUrl}api/productUpdateRequest`, { productUpdateRequest: options.productUpdateRequest });
  }
  
  public update(options: { productUpdateRequest: ProductUpdateRequest }): Observable<{ productUpdateRequest: ProductUpdateRequest }> {
    return this._client.put<{ productUpdateRequest: ProductUpdateRequest }>(`${this._baseUrl}api/productUpdateRequest`, { productUpdateRequest: options.productUpdateRequest });
  }
}

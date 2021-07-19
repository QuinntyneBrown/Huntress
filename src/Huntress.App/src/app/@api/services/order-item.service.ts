import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { OrderItem } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class OrderItemService implements IPagableService<OrderItem> {

  uniqueIdentifierName: string = "orderItemId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<OrderItem>> {
    return this._client.get<EntityPage<OrderItem>>(`${this._baseUrl}api/orderItem/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<OrderItem[]> {
    return this._client.get<{ orderItems: OrderItem[] }>(`${this._baseUrl}api/orderItem`)
      .pipe(
        map(x => x.orderItems)
      );
  }

  public getById(options: { orderItemId: string }): Observable<OrderItem> {
    return this._client.get<{ orderItem: OrderItem }>(`${this._baseUrl}api/orderItem/${options.orderItemId}`)
      .pipe(
        map(x => x.orderItem)
      );
  }

  public remove(options: { orderItem: OrderItem }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/orderItem/${options.orderItem.orderItemId}`);
  }

  public create(options: { orderItem: OrderItem }): Observable<{ orderItem: OrderItem }> {
    return this._client.post<{ orderItem: OrderItem }>(`${this._baseUrl}api/orderItem`, { orderItem: options.orderItem });
  }
  
  public update(options: { orderItem: OrderItem }): Observable<{ orderItem: OrderItem }> {
    return this._client.put<{ orderItem: OrderItem }>(`${this._baseUrl}api/orderItem`, { orderItem: options.orderItem });
  }
}

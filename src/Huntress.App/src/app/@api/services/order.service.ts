import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Order } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class OrderService implements IPagableService<Order> {

  uniqueIdentifierName: string = "orderId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Order>> {
    return this._client.get<EntityPage<Order>>(`${this._baseUrl}api/order/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Order[]> {
    return this._client.get<{ orders: Order[] }>(`${this._baseUrl}api/order`)
      .pipe(
        map(x => x.orders)
      );
  }

  public getById(options: { orderId: string }): Observable<Order> {
    return this._client.get<{ order: Order }>(`${this._baseUrl}api/order/${options.orderId}`)
      .pipe(
        map(x => x.order)
      );
  }

  public remove(options: { order: Order }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/order/${options.order.orderId}`);
  }

  public create(options: { order: Order }): Observable<{ order: Order }> {
    return this._client.post<{ order: Order }>(`${this._baseUrl}api/order`, { order: options.order });
  }
  
  public update(options: { order: Order }): Observable<{ order: Order }> {
    return this._client.put<{ order: Order }>(`${this._baseUrl}api/order`, { order: options.order });
  }
}

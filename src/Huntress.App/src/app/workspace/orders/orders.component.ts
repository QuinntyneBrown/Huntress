import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Order, OrderService } from '@api';
import { Destroyable } from '@core';
import { combineLatest, of } from 'rxjs';
import { map, switchMap, takeUntil, tap } from 'rxjs/operators';


@Component({
  selector: 'or-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss'],
  host: {
    class: 'or-page'
  }
})
export class OrdersComponent extends Destroyable {

  readonly vm$ = combineLatest([
    this._orderService.get(),
    this._activatedRoute
    .paramMap
    .pipe(
      map(paramMap => paramMap.get("orderId")),
      switchMap(orderId => orderId ? this._orderService.getById({ orderId }) : of({ }))
      )
  ])
  .pipe(
    map(([orders, selected]) => ({ orders, selected }))
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _router: Router,
    private readonly _orderService: OrderService
  ) {
    super();
  }

  public handleSelect(order: Order) {
    if(order.orderId) {
      this._router.navigate(["/","workspace","orders","edit", order.orderId]);
    } else {
      this._router.navigate(["/","workspace","orders","create"]);
    }
  }

  public handleSave(order: Order) {
    const obs$  = order.orderId ? this._orderService.update({ order }) : this._orderService.create({ order });
    obs$
    .pipe(
      takeUntil(this._destroyed$),
      tap(_ => this._router.navigate(["/","workspace","orders"])))
    .subscribe();
  }
}

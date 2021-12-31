import { ChangeDetectionStrategy, Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Order, OrderService } from '@api';
import { combine } from '@core';
import { BehaviorSubject, from, Observable, of, Subject } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';


@Component({
  selector: 'or-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class OrdersComponent {

  private readonly _saveSubject: Subject<Order> = new Subject();
  private readonly _selectSubject: Subject<Order> = new Subject();
  private readonly _createSubject: Subject<void> = new Subject();
  private readonly _deleteSubject: Subject<Order> = new Subject();
  private readonly _refreshSubject: BehaviorSubject<null> = new BehaviorSubject(null);

  readonly vm$ = this._refreshSubject
  .pipe(
    switchMap(_ => combine([
      this._orderService.get(),
      this._selected$,
      this._createSubject.pipe(switchMap(_ => this._handleCreate())),
      this._saveSubject.pipe(switchMap(order => this._handleSave(order))),
      this._selectSubject.pipe(switchMap(order => this._handleSelect(order))),
      this._deleteSubject.pipe(switchMap(order => this._handleDelete(order)))
    ])),
    map(([orders, selected]) => ({ orders, selected }))
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _orderService: OrderService,
    private readonly _router: Router,  
  ) { }

  private _handleSelect(order: Order): Observable<boolean> {
    return from(this._router.navigate(["/","orders","edit", order.orderId]));
  }

  private _handleCreate(): Observable<boolean> {
    return from(this._router.navigate(["/","orders","create"]));
  }

  private _handleSave(order: Order): Observable<boolean> {
    return (order.orderId ? this._orderService.update({ order }) : this._orderService.create({ order }))
    .pipe(      
      switchMap(_ => this._router.navigate(["/","orders"])),
      tap(_ => this._refreshSubject.next(null))
      );    
  }

  private _handleDelete(order: Order): Observable<boolean> {
    return this._orderService.remove({ order })
    .pipe(
      switchMap(_ => this._router.navigate(["/","orders"])),
      tap(_ => this._refreshSubject.next(null))
    );
  }

  private _selected$: Observable<Order> = this._activatedRoute
  .paramMap
  .pipe(
    map(x => x.get("orderId")),
    switchMap((orderId: string) => orderId ? this._orderService.getById({ orderId }) : of({} as Order)));

  onSave(order: Order) {
    this._saveSubject.next(order);
  }

  onSelect(order: Order) {
    this._selectSubject.next(order);
  }

  onCreate() {
    this._createSubject.next();
  }

  onDelete(order: Order) {
    this._deleteSubject.next(order);
  }
}

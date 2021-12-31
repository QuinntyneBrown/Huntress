import { ChangeDetectionStrategy, Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product, ProductService } from '@api';
import { combine } from '@core';
import { BehaviorSubject, from, Observable, of, Subject } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';


@Component({
  selector: 'or-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProductsComponent {

  private readonly _saveSubject: Subject<Product> = new Subject();
  private readonly _selectSubject: Subject<Product> = new Subject();
  private readonly _createSubject: Subject<void> = new Subject();
  private readonly _deleteSubject: Subject<Product> = new Subject();
  private readonly _refreshSubject: BehaviorSubject<null> = new BehaviorSubject(null);

  readonly vm$ = this._refreshSubject
  .pipe(
    switchMap(_ => combine([
      this._productService.get(),
      this._selected$,
      this._createSubject.pipe(switchMap(_ => this._handleCreate())),
      this._saveSubject.pipe(switchMap(product => this._handleSave(product))),
      this._selectSubject.pipe(switchMap(product => this._handleSelect(product))),
      this._deleteSubject.pipe(switchMap(product => this._handleDelete(product)))
    ])),
    map(([products, selected]) => ({ products, selected }))
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _productService: ProductService,
    private readonly _router: Router,  
  ) { }

  private _handleSelect(product: Product): Observable<boolean> {
    return from(this._router.navigate(["/","workspace","products","edit", product.productId]));
  }

  private _handleCreate(): Observable<boolean> {
    return from(this._router.navigate(["/","workspace","products","create"]));
  }

  private _handleSave(product: Product): Observable<boolean> {
    return (product.productId ? this._productService.update({ product }) : this._productService.create({ product }))
    .pipe(      
      switchMap(_ => this._router.navigate(["/","workspace","products"])),
      tap(_ => this._refreshSubject.next(null))
      );    
  }

  private _handleDelete(product: Product): Observable<boolean> {
    return this._productService.remove({ product })
    .pipe(
      switchMap(_ => this._router.navigate(["/","workspace","products"])),
      tap(_ => this._refreshSubject.next(null))
    );
  }

  private _selected$: Observable<Product> = this._activatedRoute
  .paramMap
  .pipe(
    map(x => x.get("productId")),
    switchMap((productId: string) => productId ? this._productService.getById({ productId }) : of({} as Product)));

  onSave(product: Product) {
    this._saveSubject.next(product);
  }

  onSelect(product: Product) {
    this._selectSubject.next(product);
  }

  onCreate() {
    this._createSubject.next();
  }

  onDelete(product: Product) {
    this._deleteSubject.next(product);
  }
}

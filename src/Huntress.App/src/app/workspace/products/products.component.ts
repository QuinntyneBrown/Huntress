import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product, ProductService } from '@api';
import { Destroyable } from '@core';
import { combineLatest, of } from 'rxjs';
import { map, switchMap, takeUntil, tap } from 'rxjs/operators';


@Component({
  selector: 'or-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent extends Destroyable {

  readonly vm$ = combineLatest([
    this._productService.get(),
    this._activatedRoute
    .paramMap
    .pipe(
      map(p => p.get("productId")),
      switchMap(productId => productId ? this._productService.getById({ productId }) : of({ }))
      )
  ])
  .pipe(
    map(([products, selected]) => ({ products, selected }))
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _router: Router,
    private readonly _productService: ProductService
  ) {
    super();
  }

  public handleSelect(product: Product) {
    if(product.productId) {
      this._router.navigate(["/","workspace","products","edit", product.productId]);
    } else {
      this._router.navigate(["/","workspace","products","create"]);
    }
  }

  public handleSave(product: Product) {
    const obs$  = product.productId ? this._productService.update({ product }) : this._productService.create({ product });
    obs$
    .pipe(
      takeUntil(this._destroyed$),
      tap(_ => this._router.navigate(["/","workspace","products"])))
    .subscribe();
  }
}

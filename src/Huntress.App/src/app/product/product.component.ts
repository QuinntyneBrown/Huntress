import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { ComponentPortal } from '@angular/cdk/portal';
import { Component, Inject, Injector } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product, ProductService } from '@api';
import { BASE_URL, combine, Destroyable } from '@core';
import { CartService } from '@shared/components/cart/cart.service';
import { merge, Subject } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';


@Component({
  selector: 'or-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent extends Destroyable {

  private _addProductActionSubject: Subject<Product> = new Subject();

  readonly vm$ = combine([
    this._activatedRoute.paramMap,
    this._addProductActionSubject
    .pipe(
      switchMap(product => this._cartService.addProduct(product)),
      tap(result => {

      })
    )
  ])
  .pipe(
    map(([paramMap]) => paramMap.get("productId")),
    switchMap(productId => this._productService.getById({ productId })),
    map(product => {
      return {
        product: Object.assign(product, {imageUrl:`${this._baseUrl}${product.productImages[0].imageUrl}`})
      }
    })
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _productService: ProductService,
    private readonly _cartService: CartService,
    @Inject(BASE_URL) private readonly _baseUrl: string
  ) {
    super();
  }

  addToCart(product: Product) {
    this._addProductActionSubject.next(product);
  }
}

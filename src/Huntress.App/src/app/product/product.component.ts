import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { ComponentPortal } from '@angular/cdk/portal';
import { Component, Inject, Injector } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product, ProductService } from '@api';
import { BASE_URL, Destroyable } from '@core';
import { merge } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';
import { CartService, CartComponent } from '../cart';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent extends Destroyable {

  readonly vm$ = this._activatedRoute.paramMap
  .pipe(
    map(paramMap => paramMap.get("productId")),
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
    private readonly _overlay: Overlay,
    private readonly _cartService: CartService,
    private readonly _router: Router,
    @Inject(BASE_URL) private readonly _baseUrl: string
  ) {
    super();
  }

  addToCart(product: Product) {
    this._cartService.addProduct(product);

    const overlayRef = this._overlay.create({
      panelClass:"or-overlay-pane",
      hasBackdrop: true,
      scrollStrategy: this._overlay.scrollStrategies.block()
    });

    const cartPortal = new ComponentPortal(CartComponent, null, Injector.create({
      providers:[
        { provide: OverlayRef, useValue: overlayRef }
      ]
    }));

    const cartComponent: CartComponent = overlayRef.attach(cartPortal).instance;

    merge(
      cartComponent.checkout$.pipe(map(_ => true)),
      cartComponent.close$.pipe(map(_ => false))
    )
    .pipe(
      tap(navigateToCheckout => {
        overlayRef.dispose();

        if(navigateToCheckout) {
          this._router.navigate(['checkout']);
        }
      })
    ).subscribe();
  }
}

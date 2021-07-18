import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { ComponentPortal } from '@angular/cdk/portal';
import { Route } from '@angular/compiler/src/core';
import { Component, Inject, Injector, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product, ProductService } from '@api';
import { baseUrl } from '@core';
import { Subject } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';
import { CartService, CartComponent } from '../cart';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnDestroy {

  private readonly _destroyed$: Subject<void> = new Subject();

  public readonly vm$ = this._activatedRoute.paramMap
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
    @Inject(baseUrl) private readonly _baseUrl: string
  ) { }

  public addToCart(product: Product) {
    this._cartService.addProduct(product);

    const overlayRef = this._overlay.create({
      panelClass:"g-overlay",
      hasBackdrop: true,
      scrollStrategy: this._overlay.scrollStrategies.block()
    });

    const cartPortal = new ComponentPortal(CartComponent, null, Injector.create({
      providers:[
        { provide: OverlayRef, useValue: overlayRef }
      ]
    }));

    const cartComponent: CartComponent = overlayRef.attach(cartPortal).instance;


    cartComponent.checkout$
    .pipe(
      tap(_ => {
        overlayRef.dispose();
        this._router.navigate(['checkout']);
      })
    ).subscribe();

  }

  ngOnDestroy() {
    this._destroyed$.next();
    this._destroyed$.complete();
  }
}

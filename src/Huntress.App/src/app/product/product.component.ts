import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { ComponentPortal } from '@angular/cdk/portal';
import { Component, Inject, Injector } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product, ProductService } from '@api';
import { baseUrl } from '@core';
import { map, switchMap } from 'rxjs/operators';
import { CartComponent } from '../cart/cart.component';
import { CartService } from '../cart/cart.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent {

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
    overlayRef.attach(cartPortal);
  }
}

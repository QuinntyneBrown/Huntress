import { OverlayRef } from '@angular/cdk/overlay';
import { Component } from '@angular/core';
import { CartService } from './cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent {
  constructor(
    private readonly _cartService: CartService,
    private readonly _overlayRef: OverlayRef
  ) {

  }

  public close() {

  }
}

import { Component, OnInit } from '@angular/core';
import { CartService } from '../cart';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent {
  constructor(
    private readonly _cartService: CartService
  ) {

  }


}

import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { combine } from '@core';
import { CartItemModule } from '../cart-item/cart-item.component';

@Component({
  selector: 'or-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent {

  readonly vm$ = combine([
    of("cart")
  ])
  .pipe(
    map(([name]) => ({ name }))
  );

  constructor(

  ) {

  }
}

@NgModule({
  declarations: [
    CartComponent
  ],
  exports: [
    CartComponent
  ],
  imports: [
    CommonModule,
    CartItemModule
  ]
})
export class CartModule { }

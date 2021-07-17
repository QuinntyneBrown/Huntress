import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartComponent } from './cart/cart.component';
import { OverlayModule } from '@angular/cdk/overlay';



@NgModule({
  declarations: [
    CartComponent
  ],
  imports: [
    CommonModule,
    OverlayModule
  ]
})
export class CartModule { }

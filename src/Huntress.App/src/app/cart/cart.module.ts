import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartComponent } from './cart.component';
import { OverlayModule } from '@angular/cdk/overlay';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ReactiveFormsModule } from '@angular/forms';
import { QuantityModule } from '@shared';
import { CartItemComponent } from './cart-item/cart-item.component';
import { MatFormFieldModule } from '@angular/material/form-field';


@NgModule({
  declarations: [
    CartComponent,
    CartItemComponent
  ],
  exports: [
    CartComponent,
    CartItemComponent
  ],
  imports: [
    CommonModule,
    OverlayModule,
    MatButtonModule,
    MatIconModule,
    ReactiveFormsModule,
    QuantityModule,
    MatFormFieldModule
  ]
})
export class CartModule { }

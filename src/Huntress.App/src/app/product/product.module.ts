import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OverlayModule } from '@angular/cdk/overlay';
import { ProductRoutingModule } from './product-routing.module';
import { ProductComponent } from './product.component';
import { MatButtonModule } from '@angular/material/button';
import { CartModule } from '../cart';



@NgModule({
  declarations: [
    ProductComponent
  ],
  imports: [
    CommonModule,
    ProductRoutingModule,
    MatButtonModule,
    OverlayModule,
    CartModule
  ]
})
export class ProductModule { }

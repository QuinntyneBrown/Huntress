import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OverlayModule } from '@angular/cdk/overlay';
import { ProductRoutingModule } from './product-routing.module';
import { ProductComponent } from './product.component';
import { MatButtonModule } from '@angular/material/button';


@NgModule({
  declarations: [
    ProductComponent
  ],
  imports: [
    CommonModule,
    ProductRoutingModule,
    MatButtonModule,
    OverlayModule
  ]
})
export class ProductModule { }

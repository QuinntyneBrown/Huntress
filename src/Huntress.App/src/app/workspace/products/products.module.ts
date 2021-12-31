import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductDetailModule, ProductListModule, ListDetailModule } from '@shared';
import { ProductsRoutingModule } from './products-routing.module';
import { ProductsComponent } from './products.component';



@NgModule({
  declarations: [
    ProductsComponent
  ],
  imports: [
    CommonModule,
    ProductsRoutingModule,
    ProductListModule,
    ProductDetailModule,
    ListDetailModule
  ]
})
export class ProductsModule { }

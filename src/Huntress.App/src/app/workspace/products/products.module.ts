import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsRoutingModule } from './products-routing.module';
import { ProductsComponent } from './products.component';
import { ProductDetailModule, ProductListModule } from '@shared';
import { ListDetailModule } from '@shared/directives/list-detail.directive';


@NgModule({
  declarations: [
    ProductsComponent
  ],
  imports: [
    CommonModule,
    ProductsRoutingModule,
    ProductDetailModule,
    ProductListModule,
    ListDetailModule
  ]
})
export class ProductsModule { }

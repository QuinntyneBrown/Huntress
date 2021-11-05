import { COMMON_FORMS_MODULES, COMMON_TABLE_MODULES } from '@shared';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsRoutingModule } from './products-routing.module';
import { ProductListComponent } from './product-list/product-list.component';


@NgModule({
  declarations: [
    ProductListComponent
  ],
  imports: [
    COMMON_FORMS_MODULES,
    COMMON_TABLE_MODULES,
    CommonModule,
    ProductsRoutingModule
  ]
})
export class ProductsModule { }

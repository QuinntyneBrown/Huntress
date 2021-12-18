import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsSectionComponent } from './products-section.component';
import { MaterialModule } from '@shared/material.module';
import { ProductCardModule } from '@shared/components/cards/product-card/product-card.module';



@NgModule({
  declarations: [
    ProductsSectionComponent
  ],
  exports: [
    ProductsSectionComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ProductCardModule
  ]
})
export class ProductsSectionModule { }

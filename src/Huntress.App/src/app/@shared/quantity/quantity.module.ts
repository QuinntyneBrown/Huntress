import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuantityComponent } from './quantity.component';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    QuantityComponent
  ],
  exports: [
    QuantityComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ]
})
export class QuantityModule { }

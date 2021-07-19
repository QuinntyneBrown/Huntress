import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartOverlayComponent } from './cart-overlay.component';
import { QuanityModule } from '@shared/quanity/quanity.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    CartOverlayComponent
  ],
  imports: [
    CommonModule,
    QuanityModule,
    ReactiveFormsModule
  ]
})
export class CartOverlayModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartComponent } from './cart.component';
import { OverlayModule } from '@angular/cdk/overlay';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ReactiveFormsModule } from '@angular/forms';
import { QuanityModule } from '@shared/quanity/quanity.module';


@NgModule({
  declarations: [
    CartComponent
  ],
  exports: [
    CartComponent
  ],
  imports: [
    CommonModule,
    OverlayModule,
    MatButtonModule,
    MatIconModule,
    ReactiveFormsModule,
    QuanityModule
  ]
})
export class CartModule { }

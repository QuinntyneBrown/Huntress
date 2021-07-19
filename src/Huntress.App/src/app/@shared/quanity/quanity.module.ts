import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuanityComponent } from './quanity.component';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    QuanityComponent
  ],
  exports: [
    QuanityComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ]
})
export class QuanityModule { }

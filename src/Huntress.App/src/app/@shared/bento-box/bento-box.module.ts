import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BentoBoxComponent } from './bento-box.component';


@NgModule({
  declarations: [
    BentoBoxComponent
  ],
  exports: [
    BentoBoxComponent
  ],
  imports: [
    CommonModule
  ]
})
export class BentoBoxModule { }

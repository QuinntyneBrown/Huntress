import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MobileHeaderComponent } from './mobile-header.component';
import { MaterialModule } from '@shared/material.module';



@NgModule({
  declarations: [
    MobileHeaderComponent
  ],
  exports: [
    MobileHeaderComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ]
})
export class MobileHeaderModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DigitalAssetsRoutingModule } from './digital-assets-routing.module';
import { MaterialModule } from '@shared/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DigitalAssetsComponent } from './digital-assets.component';


@NgModule({
  declarations: [
    DigitalAssetsComponent
  ],
  imports: [
    CommonModule,
    DigitalAssetsRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class DigitalAssetsModule { }

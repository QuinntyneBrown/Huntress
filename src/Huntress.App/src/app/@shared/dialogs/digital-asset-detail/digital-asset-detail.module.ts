import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '@shared/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DigitalAssetDetailComponent } from './digital-asset-detail.component';
import { DigitalAssetEditorModule } from '@shared/editors';



@NgModule({
  declarations: [
    DigitalAssetDetailComponent
  ],
  exports: [
    DigitalAssetDetailComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    DigitalAssetEditorModule,
    FormsModule
  ]
})
export class DigitalAssetDetailModule { }

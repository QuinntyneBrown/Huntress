import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MaterialModule } from '@shared/material.module';
import { DigitalAssetEditorComponent } from './digital-asset-editor.component';



@NgModule({
  declarations: [
    DigitalAssetEditorComponent
  ],
  exports: [
    DigitalAssetEditorComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    MaterialModule
  ]
})
export class DigitalAssetEditorModule { }

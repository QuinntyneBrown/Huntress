import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './footer.component';
import { MaterialModule } from '@shared/material.module';
import { HtmlContentSectionModule } from '@shared/sections/html-content-section/html-content-section.module';



@NgModule({
  declarations: [
    FooterComponent
  ],
  exports: [
    FooterComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    HtmlContentSectionModule
  ]
})
export class FooterModule { }

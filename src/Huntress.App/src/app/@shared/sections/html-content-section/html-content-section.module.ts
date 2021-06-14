import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HtmlContentSectionComponent } from './html-content-section.component';



@NgModule({
  declarations: [
    HtmlContentSectionComponent
  ],
  exports: [
    HtmlContentSectionComponent
  ],
  imports: [
    CommonModule
  ]
})
export class HtmlContentSectionModule { }

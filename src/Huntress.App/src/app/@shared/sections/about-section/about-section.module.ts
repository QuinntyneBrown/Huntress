import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AboutSectionComponent } from './about-section.component';



@NgModule({
  declarations: [
    AboutSectionComponent
  ],
  exports: [
    AboutSectionComponent
  ],
  imports: [
    CommonModule
  ]
})
export class AboutSectionModule { }

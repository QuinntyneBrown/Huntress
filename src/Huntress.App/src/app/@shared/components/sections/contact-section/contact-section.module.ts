import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactSectionComponent } from './contact-section.component';



@NgModule({
  declarations: [
    ContactSectionComponent
  ],
  exports: [
    ContactSectionComponent
  ],
  imports: [
    CommonModule
  ]
})
export class ContactSectionModule { }

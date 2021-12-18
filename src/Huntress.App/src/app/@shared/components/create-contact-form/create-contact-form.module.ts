import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateContactFormComponent } from './create-contact-form.component';



@NgModule({
  declarations: [
    CreateContactFormComponent
  ],
  exports: [
    CreateContactFormComponent
  ],
  imports: [
    CommonModule
  ]
})
export class CreateContactFormModule { }

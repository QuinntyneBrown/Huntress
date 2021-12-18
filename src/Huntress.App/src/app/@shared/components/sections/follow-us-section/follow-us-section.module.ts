import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FollowUsSectionComponent } from './follow-us-section.component';
import { CreateContactFormModule } from '@shared/create-contact-form';
import { MaterialModule } from '@shared/material.module';



@NgModule({
  declarations: [
    FollowUsSectionComponent
  ],
  exports: [
    FollowUsSectionComponent
  ],
  imports: [
    CommonModule,
    CreateContactFormModule,
    MaterialModule
  ]
})
export class FollowUsSectionModule { }

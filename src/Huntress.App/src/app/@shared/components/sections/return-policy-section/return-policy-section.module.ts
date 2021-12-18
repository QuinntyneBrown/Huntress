import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReturnPolicySectionComponent } from './return-policy-section.component';



@NgModule({
  declarations: [
    ReturnPolicySectionComponent
  ],
  exports: [
    ReturnPolicySectionComponent
  ],
  imports: [
    CommonModule
  ]
})
export class ReturnPolicySectionModule { }

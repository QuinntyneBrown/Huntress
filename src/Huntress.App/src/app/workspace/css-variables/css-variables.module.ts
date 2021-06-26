import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CssVariablesRoutingModule } from './css-variables-routing.module';
import { CssVariablesComponent } from './css-variables.component';


@NgModule({
  declarations: [
    CssVariablesComponent
  ],
  imports: [
    CommonModule,
    CssVariablesRoutingModule
  ]
})
export class CssVariablesModule { }

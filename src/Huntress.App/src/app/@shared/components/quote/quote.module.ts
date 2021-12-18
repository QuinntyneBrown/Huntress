import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuoteComponent } from './quote.component';


@NgModule({
  declarations: [
    QuoteComponent
  ],
  exports: [
    QuoteComponent
  ],
  imports: [
    CommonModule
  ]
})
export class QuoteModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AggregatePrivilegesComponent } from './aggregate-privileges.component';
import { MatIconModule } from '@angular/material/icon';



@NgModule({
  declarations: [
    AggregatePrivilegesComponent
  ],
  exports: [
    AggregatePrivilegesComponent
  ],
  imports: [
    CommonModule,
    MatIconModule
  ]
})
export class AggregatePrivilegesModule { }

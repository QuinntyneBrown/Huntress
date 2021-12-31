import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoleDetailModule, RoleListModule, ListDetailModule } from '@shared';
import { RolesRoutingModule } from './roles-routing.module';
import { RolesComponent } from './roles.component';



@NgModule({
  declarations: [
    RolesComponent
  ],
  imports: [
    CommonModule,
    RolesRoutingModule,
    RoleListModule,
    RoleDetailModule,
    ListDetailModule
  ]
})
export class RolesModule { }

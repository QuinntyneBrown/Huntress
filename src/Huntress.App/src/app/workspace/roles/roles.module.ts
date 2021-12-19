import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RolesRoutingModule } from './roles-routing.module';
import { BentoBoxModule, COMMON_FORMS_MODULES, COMMON_TABLE_MODULES, AggregatePrivilegesModule, RoleListModule, RoleDetailModule } from '@shared';
import { RolesComponent } from './roles.component';
import { ListDetailModule } from '@shared/directives/list-detail.directive';


@NgModule({
  declarations: [
    RolesComponent
  ],
  imports: [
    CommonModule,
    RolesRoutingModule,
    BentoBoxModule,
    AggregatePrivilegesModule,
    RoleListModule,
    RoleDetailModule,
    ListDetailModule,
    COMMON_FORMS_MODULES,
    COMMON_TABLE_MODULES
  ]
})
export class RolesModule { }

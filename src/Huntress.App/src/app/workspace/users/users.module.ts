import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersRoutingModule } from './users-routing.module';
import { UsersComponent } from './users.component';
import { UserDetailModule, UserListModule } from '@shared';
import { ListDetailModule } from '@shared/directives/list-detail.directive';



@NgModule({
  declarations: [
    UsersComponent
  ],
  imports: [
    CommonModule,
    UsersRoutingModule,
    UserListModule,
    UserDetailModule,
    ListDetailModule
  ]
})
export class UsersModule { }

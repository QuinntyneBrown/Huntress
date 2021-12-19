import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserDetailModule, UserListModule, ListDetailModule } from '@shared';
import { UsersRoutingModule } from './users-routing.module';
import { UsersComponent } from './users.component';



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

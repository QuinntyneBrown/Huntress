import { COMMON_FORMS_MODULES, COMMON_TABLE_MODULES } from '@shared';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersRoutingModule } from './users-routing.module';
import { UserListComponent } from './user-list/user-list.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { UserEditorComponent } from './user-editor/user-editor.component';
import { UserComponent } from './user/user.component';
import { BentoBoxModule } from '@shared/bento-box';


@NgModule({
  declarations: [
    UserListComponent,
    UserDetailComponent,
    UserEditorComponent,
    UserComponent
  ],
  imports: [
    COMMON_FORMS_MODULES,
    COMMON_TABLE_MODULES,
    BentoBoxModule,
    CommonModule,
    UsersRoutingModule
  ]
})
export class UsersModule { }

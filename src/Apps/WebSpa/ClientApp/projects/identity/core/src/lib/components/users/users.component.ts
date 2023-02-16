// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { UserListComponent } from './user-list/user-list.component';
import { ListDetailDirective } from '@global/list-detail';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'id-users',
  standalone: true,
  imports: [
    CommonModule, 
    UserDetailComponent, 
    UserListComponent, 
    ListDetailDirective,
    RouterModule
  ],
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent {

}



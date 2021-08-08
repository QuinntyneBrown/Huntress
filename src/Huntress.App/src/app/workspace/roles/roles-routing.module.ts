import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RoleListComponent } from './role-list/role-list.component';
import { RoleComponent } from './role/role.component';


const routes: Routes = [
  { path: '', component: RoleListComponent },
  { path: 'create', component: RoleComponent },
  { path: 'edit/:id', component: RoleComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RolesRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RolesComponent } from './roles.component';



const routes: Routes = [
  { path: '', component: RolesComponent },
  { path: 'create', component: RolesComponent },
  { path: 'edit/:roleId', component: RolesComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RolesRoutingModule { }

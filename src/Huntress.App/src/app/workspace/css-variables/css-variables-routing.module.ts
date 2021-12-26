import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CssVariablesComponent } from './css-variables.component';

const routes: Routes = [
  { path: '', component: CssVariablesComponent },
  { path: 'create', component: CssVariablesComponent },
  { path: 'edit/:cssVariableId', component: CssVariablesComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CssVariablesRoutingModule { }

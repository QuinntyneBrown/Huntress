import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContentsComponent } from './contents.component';

const routes: Routes = [
  { path: '', component: ContentsComponent },
  { path: 'create', component: ContentsComponent },
  { path: 'edit/:contentId', component: ContentsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContentsRoutingModule { }

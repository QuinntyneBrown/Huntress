import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WorkspaceComponent } from './workspace.component';

const routes: Routes = [
  {
    path: '',
    component: WorkspaceComponent,
    children: [
      {
        path:'',
        redirectTo: 'digital-assets',
        pathMatch: 'full'
      },
      {
        path: 'digital-assets', loadChildren: () => import('./digital-assets/digital-assets.module').then(m => m.DigitalAssetsModule)
      }
    ]
  },
  {  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkspaceRoutingModule { }

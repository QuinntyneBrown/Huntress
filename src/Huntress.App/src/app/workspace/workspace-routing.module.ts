import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@core';
import { WorkspaceComponent } from './workspace.component';

const routes: Routes = [
  {
    path: '',
    component: WorkspaceComponent,
    canActivate:[AuthGuard],
    children: [
      { path:'', redirectTo: 'users', pathMatch: 'full' },
      {
        path: 'digital-assets', loadChildren: () => import('./digital-assets/digital-assets.module').then(m => m.DigitalAssetsModule)
      },
      {
        path: 'css-variables', loadChildren: () => import('./css-variables/css-variables.module').then(m => m.CssVariablesModule)
      },
      {
        path: 'roles', loadChildren: () => import('./roles/roles.module').then(m => m.RolesModule)
      },
      {
        path: 'dashboard', loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule)
      },
      {
        path: 'users', loadChildren: () => import('./users/users.module').then(m => m.UsersModule)
      },
      {
        path: 'contents', loadChildren: () => import('./contents/contents.module').then(m => m.ContentsModule)
      },
      {
        path: 'products', loadChildren: () => import('./products/products.module').then(m => m.ProductsModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkspaceRoutingModule { }

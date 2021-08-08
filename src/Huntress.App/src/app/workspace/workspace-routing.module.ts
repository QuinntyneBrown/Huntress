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
      },
      {
        path: 'css-variables', loadChildren: () => import('./css-variables/css-variables.module').then(m => m.CssVariablesModule)
      },
      {
        path: 'roles', loadChildren: () => import('./roles/roles.module').then(m => m.RolesModule)
      }
    ]
  },
  { path: 'users', loadChildren: () => import('./users/users.module').then(m => m.UsersModule) },
  { path: 'products', loadChildren: () => import('./products/products.module').then(m => m.ProductsModule) },
  { path: 'users', loadChildren: () => import('./users/users.module').then(m => m.UsersModule) },
  { path: 'products', loadChildren: () => import('./products/products.module').then(m => m.ProductsModule) }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkspaceRoutingModule { }

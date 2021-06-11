import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'landing', pathMatch: 'full' },
  { path: 'landing', loadChildren: () => import('./landing/landing.module').then(m => m.LandingModule) },
  { path: 'collection', loadChildren: () => import('./collection/collection.module').then(m => m.CollectionModule) },
  { path: 'product', loadChildren: () => import('./product/product.module').then(m => m.ProductModule) },
  { path: 'workspace', loadChildren: () => import('./workspace/workspace.module').then(m => m.WorkspaceModule) },
  { path: 'login', loadChildren: () => import('./login/login.module').then(m => m.LoginModule) }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

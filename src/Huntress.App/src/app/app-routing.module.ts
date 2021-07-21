import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Route } from '@shared/shell';

const routes: Routes = [
  Route.withShell([
    { path: '', redirectTo: 'landing', pathMatch: 'full' },
    { path: 'landing', loadChildren: () => import('./landing/landing.module').then(m => m.LandingModule) },
    { path: 'collection', loadChildren: () => import('./collection/collection.module').then(m => m.CollectionModule) },
    { path: 'products', loadChildren: () => import('./product/product.module').then(m => m.ProductModule) },
    { path: 'login', loadChildren: () => import('./login/login.module').then(m => m.LoginModule) },
    { path: 'create-account', loadChildren: () => import('./create-account/create-account.module').then(m => m.CreateAccountModule) },
    { path: 'checkout', loadChildren: () => import('./checkout/checkout.module').then(m => m.CheckoutModule) }
  ]),

  { path: 'workspace', loadChildren: () => import('./workspace/workspace.module').then(m => m.WorkspaceModule) }
];

@NgModule({
  imports: [RouterModule.forRoot( routes, {
    scrollPositionRestoration: "top"
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DigitalAssetsComponent } from './digital-assets.component';

const routes: Routes = [{ path: '', component: DigitalAssetsComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DigitalAssetsRoutingModule { }

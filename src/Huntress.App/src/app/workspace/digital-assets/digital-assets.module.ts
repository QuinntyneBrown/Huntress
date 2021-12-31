import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DigitalAssetDetailModule, DigitalAssetListModule, ListDetailModule } from '@shared';
import { DigitalAssetsRoutingModule } from './digital-assets-routing.module';
import { DigitalAssetsComponent } from './digital-assets.component';



@NgModule({
  declarations: [
    DigitalAssetsComponent
  ],
  imports: [
    CommonModule,
    DigitalAssetsRoutingModule,
    DigitalAssetListModule,
    DigitalAssetDetailModule,
    ListDetailModule
  ]
})
export class DigitalAssetsModule { }

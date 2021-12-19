import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DigitalAssetsRoutingModule } from './digital-assets-routing.module';
import { DigitalAssetsComponent } from './digital-assets.component';
import { COMMON_TABLE_MODULES, DigitalAssetDetailModule, DigitalAssetListModule } from '@shared';
import { ListDetailModule } from '@shared/directives/list-detail.directive';


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

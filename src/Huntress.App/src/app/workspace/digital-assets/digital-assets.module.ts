import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DigitalAssetsRoutingModule } from './digital-assets-routing.module';
import { DigitalAssetsComponent } from './digital-assets.component';
import { COMMON_TABLE_MODULES } from '@shared';


@NgModule({
  declarations: [
    DigitalAssetsComponent
  ],
  imports: [
    CommonModule,
    DigitalAssetsRoutingModule,
    COMMON_TABLE_MODULES
  ]
})
export class DigitalAssetsModule { }

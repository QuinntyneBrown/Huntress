import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LandingRoutingModule } from './landing-routing.module';
import { LandingComponent } from './landing.component';
import { HeroModule } from '@shared/hero/hero.module';
import { HttpClientModule } from '@angular/common/http';
import { MaterialModule } from '@shared/material.module';


@NgModule({
  declarations: [
    LandingComponent
  ],
  imports: [
    CommonModule,
    LandingRoutingModule,
    HeroModule,
    HttpClientModule,
    MaterialModule
  ]
})
export class LandingModule { }

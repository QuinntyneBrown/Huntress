import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LandingRoutingModule } from './landing-routing.module';
import { LandingComponent } from './landing.component';
import { HttpClientModule } from '@angular/common/http';
import { MaterialModule } from '@shared/material.module';
import { ProductsSectionModule } from '@shared';
import { QuoteModule } from '@shared';
import { HeroModule } from '@shared/components/hero/hero.module';


@NgModule({
  declarations: [
    LandingComponent
  ],
  imports: [
    CommonModule,
    LandingRoutingModule,
    HeroModule,
    HttpClientModule,
    MaterialModule,
    ProductsSectionModule,
    QuoteModule
  ]
})
export class LandingModule { }

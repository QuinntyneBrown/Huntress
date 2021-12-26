import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'or-landing-content-detail',
  templateUrl: './landing-content-detail.component.html',
  styleUrls: ['./landing-content-detail.component.scss']
})
export class LandingContentDetailComponent {

  readonly vm$ = of({ })
  .pipe(
    map(model => ({ model }))
  );

  constructor(

  ) {

  }
}

@NgModule({
  declarations: [
    LandingContentDetailComponent
  ],
  exports: [
    LandingContentDetailComponent
  ],
  imports: [
    CommonModule,
  ]
})
export class LandingContentDetailModule { }

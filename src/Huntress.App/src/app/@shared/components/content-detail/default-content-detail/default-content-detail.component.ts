import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'or-default-content-detail',
  templateUrl: './default-content-detail.component.html',
  styleUrls: ['./default-content-detail.component.scss']
})
export class DefaultContentDetailComponent {

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
    DefaultContentDetailComponent
  ],
  exports: [
    DefaultContentDetailComponent
  ],
  imports: [
    CommonModule,
  ]
})
export class DefaultContentDetailModule { }

import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'or-shell-content-detail',
  templateUrl: './shell-content-detail.component.html',
  styleUrls: ['./shell-content-detail.component.scss']
})
export class ShellContentDetailComponent {

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
    ShellContentDetailComponent
  ],
  exports: [
    ShellContentDetailComponent
  ],
  imports: [
    CommonModule,
  ]
})
export class ShellContentDetailModule { }

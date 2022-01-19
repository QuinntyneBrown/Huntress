import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { combine } from '@core';

@Component({
  selector: 'or-workspace-footer',
  templateUrl: './workspace-footer.component.html',
  styleUrls: ['./workspace-footer.component.scss']
})
export class WorkspaceFooterComponent {

  readonly vm$ = combine([
    of({ })
  ])
  .pipe(
    map(([model]) => ({ model }))
  );

  constructor(

  ) {

  }
}

@NgModule({
  declarations: [
    WorkspaceFooterComponent
  ],
  exports: [
    WorkspaceFooterComponent
  ],
  imports: [
    CommonModule,
  ]
})
export class WorkspaceFooterModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkspacePanelDirective } from './workspace-panel.directive';



@NgModule({
  declarations: [
    WorkspacePanelDirective
  ],
  exports: [
    WorkspacePanelDirective
  ],
  imports: [
    CommonModule
  ]
})
export class WorkspacePanelModule { }

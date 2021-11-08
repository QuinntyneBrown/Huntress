import { Directive, ElementRef } from '@angular/core';

@Directive({
  selector: '[appWorkspacePanel]',
  host: {
    'class': 'g-workspace-panel'
  }
})
export class WorkspacePanelDirective { }

import { Directive, ElementRef } from '@angular/core';

@Directive({
  selector: '[appWorkspacePanel]',
  host: {
    'class': 'or-workspace-panel'
  }
})
export class WorkspacePanelDirective { }

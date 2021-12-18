import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkspaceRoutingModule } from './workspace-routing.module';
import { WorkspaceComponent } from './workspace.component';
import { MaterialModule, SidenavModule } from '@shared';
import { MobileHeaderModule } from '@shared/components/mobile-header/mobile-header.module';
import { WorkspacePanelModule } from '@shared/components/workspace-panel/workspace-panel.module';



@NgModule({
  declarations: [
    WorkspaceComponent
  ],
  imports: [
    CommonModule,
    SidenavModule,
    WorkspaceRoutingModule,
    MaterialModule,
    MobileHeaderModule,
    WorkspacePanelModule
  ]
})
export class WorkspaceModule { }

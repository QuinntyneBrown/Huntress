import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkspaceRoutingModule } from './workspace-routing.module';
import { WorkspaceComponent } from './workspace.component';
import { SidenavModule } from '@shared/sidenav/sidenav.module';
import { MaterialModule } from '@shared';
import { MobileHeaderModule } from '@shared/mobile-header/mobile-header.module';


@NgModule({
  declarations: [
    WorkspaceComponent
  ],
  imports: [
    CommonModule,
    SidenavModule,
    WorkspaceRoutingModule,
    MaterialModule,
    MobileHeaderModule
  ]
})
export class WorkspaceModule { }

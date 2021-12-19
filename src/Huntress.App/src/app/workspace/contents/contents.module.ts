import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContentsRoutingModule } from './contents-routing.module';
import { ContentsComponent } from './contents.component';
import { ListDetailModule } from '@shared/directives/list-detail.directive';
import { ContentDetailModule, ContentListModule } from '@shared';


@NgModule({
  declarations: [
    ContentsComponent
  ],
  imports: [
    CommonModule,
    ContentsRoutingModule,
    ListDetailModule,
    ContentListModule,
    ContentDetailModule
  ]
})
export class ContentsModule { }

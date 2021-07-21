import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShellComponent } from './shell.component';
import { RouterModule } from '@angular/router';
import { HeaderModule } from '@shared/header/header.module';
import { FooterModule } from '@shared/footer';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';



@NgModule({
  declarations: [
    ShellComponent
  ],
  exports: [
    ShellComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    HeaderModule,
    FooterModule,
    MatSidenavModule,
    MatButtonModule,
    MatIconModule
  ]
})
export class ShellModule { }

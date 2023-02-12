// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  standalone: true,
  imports: [
    HeaderComponent,
    CommonModule,
    RouterModule
  ]
})
export class AppComponent {
  constructor(private readonly _translateService: TranslateService) {
    _translateService.setDefaultLang("en");
    _translateService.use(localStorage.getItem("currentLanguage") || "en");
  }
}

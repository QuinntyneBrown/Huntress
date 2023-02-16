// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { LocalStorageService } from '@global/core';
import { HtmlEditorComponent } from '@global/html-editor';
import { TranslateService } from '@ngx-translate/core';
import { HeaderComponent } from './header/header.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    HeaderComponent,
    HtmlEditorComponent,
    ReactiveFormsModule
  ]
})
export class AppComponent {
  constructor(
    private readonly _translateService: TranslateService,
    private readonly _localStorageService: LocalStorageService
    ) {
      const currentLanguage = _localStorageService.get({ name: "currentLanguage"});       
      _translateService.setDefaultLang("en");
      _translateService.use(currentLanguage || "en");
  }

  formControl = new FormControl('',[]);
}

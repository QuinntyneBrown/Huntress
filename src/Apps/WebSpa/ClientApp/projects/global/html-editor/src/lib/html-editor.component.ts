// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Component, forwardRef, Inject } from '@angular/core';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { BaseControl } from '@global/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { CKEditorModule, CKEditor4  } from 'ckeditor4-angular';
import { BASE_URL } from './constants';


@Component({
  selector: 'g-html-editor',
  standalone: true,  
  templateUrl: './html-editor.component.html',
  styleUrls: ['./html-editor.component.scss'],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CKEditorModule
  ],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => HtmlEditorComponent),
      multi: true
    }
  ]
})
export class HtmlEditorComponent extends BaseControl {

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl:string
  ) {
    super();
  }

  data:any;

  readonly config = {
    removeDialogTabs :'image:advanced;image:Link;link:advanced;link:upload',
    filebrowserImageUploadUrl: `${this._baseUrl}api/digitalasset/upload?single=true`
  };

  handleChange($event: CKEditor4.EventInfo) { this.registerOnChangeFn($event.editor.getData()); }

  writeValue(obj: any): void {
    this.data = obj;
  }

  registerOnChangeFn:any;

  registerOnChange(fn: any): void {
    this.registerOnChangeFn = fn;
  }
}

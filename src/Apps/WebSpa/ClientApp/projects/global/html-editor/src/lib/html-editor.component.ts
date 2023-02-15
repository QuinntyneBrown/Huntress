// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Component, forwardRef, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { BaseControl } from '@global/core';
import { BASE_URL } from './constants';
import { NG_VALUE_ACCESSOR } from '@angular/forms';


@Component({
  selector: 'g-html-editor',
  standalone: true,
  imports: [CommonModule, CKEditorModule],
  templateUrl: './html-editor.component.html',
  styleUrls: ['./html-editor.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => HtmlEditorComponent),
      multi: true
    }
  ]
})
export class HtmlEditorComponent extends BaseControl {
  data: any;

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl:string
  ) {
    super();
  }
  readonly config = {
    removeDialogTabs: 'image:advanced;image:Link;link:advanced;link:upload',
    filebrowserImageUploadUrl: `${this._baseUrl}api/digitalasset/upload?single=true`
  };

  handleChange($event: any) { this.registerOnChangeFn($event.editor.getData()); }

  writeValue(obj: any): void {
    this.data = obj;
  }

  registerOnChangeFn: any;

  registerOnChange(fn: any): void {
    this.registerOnChangeFn = fn;
  }
}


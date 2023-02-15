// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Component, Injectable, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { AbstractControl, AsyncValidatorFn, ControlValueAccessor, FormArray, FormControlStatus, FormGroup, ValidationErrors, ValidatorFn, ɵGetProperty } from '@angular/forms';
import { Observable, Subject } from 'rxjs';
import { BaseControl } from '@global/core';


@Component({
  selector: 'g-html-editor',
  standalone: true,
  imports: [CommonModule, CKEditorModule],
  templateUrl: './html-editor.component.html',
  styleUrls: ['./html-editor.component.scss']
})
export class HtmlEditorComponent extends BaseControl {
  data: any;

  readonly config = {
    removeDialogTabs: 'image:advanced;image:Link;link:advanced;link:upload',
    filebrowserImageUploadUrl: "https://localhost:5001/api/digitalasset/upload?single=true"
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


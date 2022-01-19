import { Component, forwardRef, Inject } from '@angular/core';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { CKEditorModule, CKEditor4  } from 'ckeditor4-angular';
import { BaseControl } from '@core/base-control';
import { BASE_URL } from '@core';


@Component({
  selector: 'or-html-editor',
  template: `
    <ckeditor [data]="data" [config]="config" (change)="handleChange($event)"></ckeditor>
  `,
  styles: [
    `
      :host {
        display:block;
        box-sizing:border-box;
      }
    `
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

  data:any;

  readonly config = {
    removeDialogTabs :'image:advanced;image:Link;link:advanced;link:upload',
    filebrowserImageUploadUrl: `${this._baseUrl}api/digitalasset/upload?single=true`
  };

  constructor(
    @Inject(BASE_URL)private readonly _baseUrl: string
  ) {
    super();
  }
  handleChange($event: CKEditor4.EventInfo) { this.registerOnChangeFn($event.editor.getData()); }

  writeValue(obj: any): void {
    this.data = obj;
  }

  registerOnChangeFn:any;

  registerOnChange(fn: any): void {
    this.registerOnChangeFn = fn;
  }
}

@NgModule({
  declarations: [
    HtmlEditorComponent
  ],
  exports: [
    HtmlEditorComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CKEditorModule
  ]
})
export class HtmlEditorModule { }

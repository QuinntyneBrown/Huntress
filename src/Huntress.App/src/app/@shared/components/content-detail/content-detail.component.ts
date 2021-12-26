import { Component, EventEmitter, Injectable, Input, NgModule, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Content } from '@api';
import { HtmlEditorModule } from '@shared';
import { LandingContentDetailModule, ShellContentDetailModule } from '.';
import { DefaultContentDetailModule } from './default-content-detail';

@Injectable()
export abstract class BaseContentDetailComponent {

  form: FormGroup;

  get content(): Content { return this.form.value as Content; }

  @Output() save: EventEmitter<Content> = new EventEmitter();

  @Output() backButtonClick: EventEmitter<void>  = new EventEmitter();

  setContent(value: Content) {
    if(!value?.contentId) {
      this.form.reset({
        name: null
      })
    } else {
      this.form.patchValue(value);
    }
  }

}

@Component({
  selector: 'or-content-detail',
  templateUrl: './content-detail.component.html',
  styleUrls: ['./content-detail.component.scss']
})
export class ContentDetailComponent extends BaseContentDetailComponent {
  form: FormGroup = new FormGroup({
    contentId: new FormControl(null, []),
    name: new FormControl(null, [Validators.required])
  });

  @Input("content") set content(value: Content) {
    this.setContent(value);
  }
}

@NgModule({
  declarations: [
    ContentDetailComponent
  ],
  exports: [
    ContentDetailComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    ReactiveFormsModule,
    HtmlEditorModule,
    ShellContentDetailModule,
    LandingContentDetailModule,
    DefaultContentDetailModule
  ]
})
export class ContentDetailModule { }

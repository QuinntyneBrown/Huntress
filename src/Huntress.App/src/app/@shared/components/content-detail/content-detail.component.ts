import { Component, EventEmitter, Input, NgModule, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Content } from '@api';
import { HtmlEditorModule } from '@shared';

@Component({
  selector: 'or-content-detail',
  templateUrl: './content-detail.component.html',
  styleUrls: ['./content-detail.component.scss']
})
export class ContentDetailComponent {

  readonly form: FormGroup = new FormGroup({
    contentId: new FormControl(null, []),
    name: new FormControl(null, [Validators.required])
  });

  public get content(): Content { return this.form.value as Content; }

  @Input("content") public set user(value: Content) {
    if(!value?.contentId) {
      this.form.reset({
        name: null
      })
    } else {
      this.form.patchValue(value);
    }
  }

  @Output() save: EventEmitter<Content> = new EventEmitter();
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
    HtmlEditorModule
  ]
})
export class ContentDetailModule { }

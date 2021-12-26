import { Component, EventEmitter, Input, NgModule, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { CssVariable } from '@api';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'or-css-variable-detail',
  templateUrl: './css-variable-detail.component.html',
  styleUrls: ['./css-variable-detail.component.scss']
})
export class CssVariableDetailComponent {

  readonly form: FormGroup = new FormGroup({
    cssVariableId: new FormControl(null, []),
    name: new FormControl(null, [Validators.required])
  });

  public get cssVariable(): CssVariable { return this.form.value as CssVariable; }

  @Input("cssVariable") public set cssVariable(value: CssVariable) {
    if(!value?.cssVariableId) {
      this.form.reset({
        name: null
      })
    } else {
      this.form.patchValue(value);
    }
  }

  @Output() save: EventEmitter<CssVariable> = new EventEmitter();

}

@NgModule({
  declarations: [
    CssVariableDetailComponent
  ],
  exports: [
    CssVariableDetailComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    ReactiveFormsModule
  ]
})
export class CssVariableDetailModule { }

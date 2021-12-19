import { Component, EventEmitter, Input, NgModule, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { Role } from '@api';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'or-role-detail',
  templateUrl: './role-detail.component.html',
  styleUrls: ['./role-detail.component.scss']
})
export class RoleDetailComponent {

  readonly form: FormGroup = new FormGroup({
    roleId: new FormControl(null, []),
    name: new FormControl(null, [Validators.required])
  });

  public get role(): Role { return this.form.value as Role; }

  @Input("role") public set role(value: Role) {
    if(!value?.roleId) {
      this.form.reset({
        name: null
      })
    } else {
      this.form.patchValue(value);
    }
  }

  @Output() save: EventEmitter<Role> = new EventEmitter();

}

@NgModule({
  declarations: [
    RoleDetailComponent
  ],
  exports: [
    RoleDetailComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    ReactiveFormsModule
  ]
})
export class RoleDetailModule { }

import { Component, EventEmitter, Input, NgModule, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { MatIconModule } from '@angular/material/icon';
import { User } from '@api';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'or-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.scss'],
  host: {
    class:'or-list-detail-container--detail'
  }
})
export class UserDetailComponent {

  readonly form: FormGroup = new FormGroup({
    userId: new FormControl(null, []),
    username: new FormControl(null, [Validators.required])
  });

  public get user(): User { return this.form.value as User; }

  @Input("user") public set user(value: User) {
    if(!value?.userId) {
      this.form.reset({
        username: null
      })
    } else {
      this.form.patchValue(value);
    }
  }

  @Output() save: EventEmitter<User> = new EventEmitter();

}

@NgModule({
  declarations: [
    UserDetailComponent
  ],
  exports: [
    UserDetailComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    ReactiveFormsModule
  ]
})
export class UserDetailModule { }

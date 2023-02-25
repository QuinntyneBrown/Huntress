// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services';
import { takeUntil } from 'rxjs';
import { MatButtonModule } from '@angular/material/button';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { MatInputModule } from '@angular/material/input';
import { Destroyable } from '@global/core';

@Component({
  selector: 'idp-login',
  standalone: true,
  imports: [
    CommonModule,
    MatButtonModule,
    ReactiveFormsModule,
    TranslateModule,
    MatInputModule
  ],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent extends Destroyable {
  constructor(
    private readonly _authService: AuthService,
  ) {
    super();
  }

  public form = new FormGroup({
    username: new FormControl('',[Validators.required]),
    password: new FormControl('',[Validators.required])
  });

  public tryToLogin(credentials: any) {
    this._authService.tryToLogin({
      username: credentials.username,
      password: credentials.password
    })
      .pipe(
        takeUntil(this._destroyed$),
      ).subscribe();
  }
}




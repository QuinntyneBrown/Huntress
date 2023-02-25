// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent as IdentityLoginComponent } from '@identity/core';
import { createViewModel } from './login.view-model';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, IdentityLoginComponent],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  public vm$ = createViewModel();

}

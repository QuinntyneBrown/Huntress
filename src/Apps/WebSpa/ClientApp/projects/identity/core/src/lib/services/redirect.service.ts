// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { DEFAULT_PATH, LOGIN_PATH } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class RedirectService {

  constructor(
    @Inject(LOGIN_PATH) private readonly _loginPath: string,
    @Inject(DEFAULT_PATH) private readonly _defaultPath: string,
    private readonly _router: Router
  ) { }

  lastPath = '';

  public redirectToLogin(): void {
    this._router.navigate([this._loginPath]);
  }

  public redirectPreLogin(): void {
    if (this.lastPath && this.lastPath !== this._loginPath) {
      this._router.navigateByUrl(this.lastPath);
      this.lastPath = '';
    } else {
      this._router.navigateByUrl(this._defaultPath);
    }
  }
}


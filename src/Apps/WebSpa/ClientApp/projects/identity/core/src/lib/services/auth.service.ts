// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  public tryToLogout() {

  }

  public tryToLogin(options: { username: string, password: string }): Observable<string> {
    return of("");
  }
}


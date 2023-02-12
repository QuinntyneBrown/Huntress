// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Inject, Injectable } from '@angular/core';
import { Observable, of, ReplaySubject, tap } from 'rxjs';
import { BASE_URL } from '../constants';
import { HttpClient } from '@angular/common/http';
import { User } from '../models';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private _currentUserSubject: ReplaySubject<User|null> = new ReplaySubject(1);
  
  public currentUser$: Observable<User|null> = this._currentUserSubject.asObservable();

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl:string,
    private readonly _httpClient: HttpClient
  ) { }

  public tryToLogout() {
    this._currentUserSubject.next(null);
    localStorage.removeItem("accessToken");
  }

  public tryToLogin(options: { username: string, password: string }): Observable<string> {
    return this._httpClient.post<any>(`${this._baseUrl}api/user/authenticate`, options)
    .pipe(
      tap(response => {
        localStorage.setItem("accessToken", response.accessToken)
      }),
      tap(x => this._currentUserSubject.next({ username: options.username }))
    );
  }
}


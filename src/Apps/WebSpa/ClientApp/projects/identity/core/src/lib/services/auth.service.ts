// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { inject, Inject, Injectable } from '@angular/core';
import { Observable, of, ReplaySubject, tap } from 'rxjs';
import { ACCESS_TOKEN_KEY, BASE_URL } from '../constants';
import { HttpClient } from '@angular/common/http';
import { User } from '../models';
import { LocalStorageService } from '@global/core';
import { RedirectService } from './redirect.service';
import { ActivatedRoute, ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private _currentUserSubject: ReplaySubject<User|null> = new ReplaySubject(1);
  
  public currentUser$: Observable<User|null> = this._currentUserSubject.asObservable();

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _localStorageService: LocalStorageService,
    private readonly _httpClient: HttpClient,
    private readonly _redirectService: RedirectService
  ) { }

  public authorize(
    route = inject(ActivatedRoute).snapshot,
    state = inject(Router).routerState.snapshot) 
    {
    
    const token = this._localStorageService.get({ name: ACCESS_TOKEN_KEY });
    
    if (token) {
      return true;
    }

    this._redirectService.lastPath = state.url;

    this._redirectService.redirectToLogin();  
    
    return false;
  }

  public tryToLogout() {
    this._currentUserSubject.next(null);
    this._localStorageService.put({ name: ACCESS_TOKEN_KEY, value: null });
  }

  public tryToLogin(options: { username: string, password: string }): Observable<string> {
    return this._httpClient.post<any>(`${this._baseUrl}api/user/authenticate`, options)
    .pipe(
      tap(response => {
        this._localStorageService.put({ name: ACCESS_TOKEN_KEY, value: response.accessToken });
      }),
      tap(x => this._currentUserSubject.next({ username: options.username }))
    );
  }
}


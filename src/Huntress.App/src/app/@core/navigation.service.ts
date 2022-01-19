import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { from, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class NavigationService {
  constructor(
    private readonly _router: Router
    ) { }

  private _loginUrl = '/login';

  private _lastPath: string = '';

  private _defaultPath = '/workspace';

  setLastPath(value: string): void {
    this._lastPath = value;
  }

  setLoginUrl(value: string): void {
    this._loginUrl = value;
  }

  setDefaultUrl(value: string): void {
    this._defaultPath = value;
  }

  redirectToLogin(): void {
    this._router.navigate([this._loginUrl]);
  }

  redirectToPublicDefault(): void {
    this._router.navigate(['']);
  }

  redirectPreLogin(): Observable<boolean> {
    const url = (this._lastPath && this._lastPath !== this._loginUrl) ? this._lastPath : this._defaultPath;
    return from(this._router.navigateByUrl(url))
      .pipe(
        tap(_ => (this._lastPath = undefined))
      )
  }
}

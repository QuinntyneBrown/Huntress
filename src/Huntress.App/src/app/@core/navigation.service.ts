import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

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

  redirectPreLogin(): void {
    if (this._lastPath && this._lastPath !== this._loginUrl) {
      this._router.navigateByUrl(this._lastPath);
      this._lastPath = '';
    } else {
      this._router.navigate([this._defaultPath]);
    }
  }
}

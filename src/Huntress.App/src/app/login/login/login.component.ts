import { Component, ChangeDetectionStrategy } from '@angular/core';
import { map, switchMap } from 'rxjs/operators';
import { of, Subject } from 'rxjs';
import { AuthService } from '@core/auth.service';
import { NavigationService } from '@core/navigation.service';
import { combine } from '@core';

@Component({
  selector: 'or-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LoginComponent  {

  private readonly _loginSubject: Subject<{ username: string, password:string}> = new Subject();

  readonly vm$ = combine([
    of(this._authService.logout()),
    this._loginSubject
    .pipe(
      switchMap(credentials => this._handleTryToLogin(credentials)),
      switchMap(_ => this._navigationService.redirectPreLogin())
    )
  ])
  .pipe(
    map(_ => ({ }))
  );

  constructor(
    private readonly _authService: AuthService,
    private readonly _navigationService: NavigationService
  ) { }

  private _handleTryToLogin($event: { username: string, password: string }) {
    return this._authService
    .tryToLogin({
      username: $event.username,
      password: $event.password
    });    
  }

  onTryToLogin($event: { username: string, password: string }) {
    this._loginSubject.next($event)
  }
}

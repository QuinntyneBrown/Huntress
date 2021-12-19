import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '@api';
import { Destroyable } from '@core';
import { UserStore } from '@core/stores/user.store';
import { combineLatest, of } from 'rxjs';
import { map, switchMap, takeUntil, tap } from 'rxjs/operators';


@Component({
  selector: 'or-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent extends Destroyable {

  readonly vm$ = combineLatest([
    this._userStore.get$(),
    this._activatedRoute
    .paramMap
    .pipe(
      map(p => p.get("userId")),
      switchMap(userId => userId ? this._userStore.getById({ userId }) : of({ }))
      )
  ])
  .pipe(
    map(([users, selected]) => ({ users, selected }))
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _router: Router,
    private readonly _userStore: UserStore
  ) {
    super();
  }

  public handleSelect(user: User) {
    if(user.userId) {
      this._router.navigate(["/","workspace","users","edit", user.userId]);
    } else {
      this._router.navigate(["/","workspace","users","create"]);
    }
  }

  public handleSave(user: User) {
    const obs$  = user.userId ? this._userStore.update$(user) : this._userStore.create$(user);
    obs$
    .pipe(
      takeUntil(this._destroyed$),
      tap(_ => this._router.navigate(["/","workspace","users"])))
    .subscribe();
  }
}

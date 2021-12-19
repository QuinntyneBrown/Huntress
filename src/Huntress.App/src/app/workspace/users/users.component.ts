import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User, UserService } from '@api';
import { Destroyable } from '@core';
import { combineLatest, of } from 'rxjs';
import { map, switchMap, takeUntil, tap } from 'rxjs/operators';


@Component({
  selector: 'or-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent extends Destroyable {

  readonly vm$ = combineLatest([
    this._userService.get(),
    this._activatedRoute
    .paramMap
    .pipe(
      map(p => p.get("userId")),
      switchMap(userId => userId ? this._userService.getById({ userId }) : of({ }))
      )
  ])
  .pipe(
    map(([users, selected]) => ({ users, selected }))
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _router: Router,
    private readonly _userService: UserService
  ) {
    super();
  }

  public handleSelect(user: User) {
    if(user.userId) {
      this._router.navigate(["../","workspace","roles"]);
    } else {
      this._router.navigate(["/","workspace","users","create"]);
    }
  }

  public handleSave(user: User) {
    const obs$  = user.userId ? this._userService.update({user}) : this._userService.create({user});
    obs$
    .pipe(
      takeUntil(this._destroyed$),
      tap(_ => this._router.navigate(["/","workspace","users"])))
    .subscribe();
  }
}

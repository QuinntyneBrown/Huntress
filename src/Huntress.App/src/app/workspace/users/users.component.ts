import { Component } from '@angular/core';
import { User } from '@api';
import { UserStore } from '@core/stores/user.store';
import { combineLatest } from 'rxjs';
import { map, tap } from 'rxjs/operators';

@Component({
  selector: 'or-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent {

  readonly vm$ = combineLatest([this._userStore.get$(), this._userStore.selected$])
  .pipe(
    map(([users, selected]) => {

      console.log(selected);

      return { users, selected };
    })
  );

  constructor(
    private readonly _userStore: UserStore
  ) { }

  public handleSelect(user: User) {
    this._userStore.setSelected(user);
  }

  public handleSave(user: User) {
    const obs$  = user.userId ? this._userStore.update$(user) : this._userStore.create$(user);
    obs$
    .pipe(tap(_ => this._userStore.clearSelected()))
    .subscribe();
  }
}

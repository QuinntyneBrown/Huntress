import { ChangeDetectionStrategy, Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User, UserService } from '@api';
import { combine } from '@core';
import { BehaviorSubject, from, Observable, of, Subject } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';


@Component({
  selector: 'or-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UsersComponent {

  private readonly _saveSubject: Subject<User> = new Subject();
  private readonly _selectSubject: Subject<User> = new Subject();
  private readonly _createSubject: Subject<void> = new Subject();
  private readonly _deleteSubject: Subject<User> = new Subject();
  private readonly _refreshSubject: BehaviorSubject<null> = new BehaviorSubject(null);

  readonly vm$ = this._refreshSubject
  .pipe(
    switchMap(_ => combine([
      this._userService.get(),
      this._selected$,
      this._createSubject.pipe(switchMap(_ => this._handleCreate())),
      this._saveSubject.pipe(switchMap(user => this._handleSave(user))),
      this._selectSubject.pipe(switchMap(user => this._handleSelect(user))),
      this._deleteSubject.pipe(switchMap(user => this._handleDelete(user)))
    ])),
    map(([users, selected]) => ({ users, selected }))
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _userService: UserService,
    private readonly _router: Router,  
  ) { }

  private _handleSelect(user: User): Observable<boolean> {
    return from(this._router.navigate(["/","workspace","users","edit", user.userId]));
  }

  private _handleCreate(): Observable<boolean> {
    return from(this._router.navigate(["/","workspace","users","create"]));
  }

  private _handleSave(user: User): Observable<boolean> {
    return (user.userId ? this._userService.update({ user }) : this._userService.create({ user }))
    .pipe(      
      switchMap(_ => this._router.navigate(["/","workspace","users"])),
      tap(_ => this._refreshSubject.next(null))
      );    
  }

  private _handleDelete(user: User): Observable<boolean> {
    return this._userService.remove({ user })
    .pipe(
      switchMap(_ => this._router.navigate(["/","workspace","users"])),
      tap(_ => this._refreshSubject.next(null))
    );
  }

  private _selected$: Observable<User> = this._activatedRoute
  .paramMap
  .pipe(
    map(x => x.get("userId")),
    switchMap((userId: string) => userId ? this._userService.getById({ userId }) : of({} as User)));

  onSave(user: User) {
    this._saveSubject.next(user);
  }

  onSelect(user: User) {
    this._selectSubject.next(user);
  }

  onCreate() {
    this._createSubject.next();
  }

  onDelete(user: User) {
    this._deleteSubject.next(user);
  }
}

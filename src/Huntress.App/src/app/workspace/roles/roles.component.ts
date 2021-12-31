import { ChangeDetectionStrategy, Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Role, RoleService } from '@api';
import { combine } from '@core';
import { BehaviorSubject, from, Observable, of, Subject } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';


@Component({
  selector: 'or-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RolesComponent {

  private readonly _saveSubject: Subject<Role> = new Subject();
  private readonly _selectSubject: Subject<Role> = new Subject();
  private readonly _createSubject: Subject<void> = new Subject();
  private readonly _deleteSubject: Subject<Role> = new Subject();
  private readonly _refreshSubject: BehaviorSubject<null> = new BehaviorSubject(null);

  readonly vm$ = this._refreshSubject
  .pipe(
    switchMap(_ => combine([
      this._roleService.get(),
      this._selected$,
      this._createSubject.pipe(switchMap(_ => this._handleCreate())),
      this._saveSubject.pipe(switchMap(role => this._handleSave(role))),
      this._selectSubject.pipe(switchMap(role => this._handleSelect(role))),
      this._deleteSubject.pipe(switchMap(role => this._handleDelete(role)))
    ])),
    map(([roles, selected]) => ({ roles, selected }))
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _roleService: RoleService,
    private readonly _router: Router,  
  ) { }

  private _handleSelect(role: Role): Observable<boolean> {
    return from(this._router.navigate(["/","workspace","roles","edit", role.roleId]));
  }

  private _handleCreate(): Observable<boolean> {
    return from(this._router.navigate(["/","workspace","roles","create"]));
  }

  private _handleSave(role: Role): Observable<boolean> {
    return (role.roleId ? this._roleService.update({ role }) : this._roleService.create({ role }))
    .pipe(      
      switchMap(_ => this._router.navigate(["/","workspace","roles"])),
      tap(_ => this._refreshSubject.next(null))
      );    
  }

  private _handleDelete(role: Role): Observable<boolean> {
    return this._roleService.remove({ role })
    .pipe(
      switchMap(_ => this._router.navigate(["/","workspace","roles"])),
      tap(_ => this._refreshSubject.next(null))
    );
  }

  private _selected$: Observable<Role> = this._activatedRoute
  .paramMap
  .pipe(
    map(x => x.get("roleId")),
    switchMap((roleId: string) => roleId ? this._roleService.getById({ roleId }) : of({} as Role)));

  onSave(role: Role) {
    this._saveSubject.next(role);
  }

  onSelect(role: Role) {
    this._selectSubject.next(role);
  }

  onCreate() {
    this._createSubject.next();
  }

  onDelete(role: Role) {
    this._deleteSubject.next(role);
  }
}

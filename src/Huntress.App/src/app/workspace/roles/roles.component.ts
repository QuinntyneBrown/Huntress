import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Role, RoleService } from '@api';
import { Destroyable } from '@core';
import { combineLatest, of } from 'rxjs';
import { map, switchMap, takeUntil, tap } from 'rxjs/operators';


@Component({
  selector: 'or-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.scss']
})
export class RolesComponent extends Destroyable {

  readonly vm$ = combineLatest([
    this._roleService.get(),
    this._activatedRoute
    .paramMap
    .pipe(
      map(p => p.get("roleId")),
      switchMap(roleId => roleId ? this._roleService.getById({ roleId }) : of({ }))
      )
  ])
  .pipe(
    map(([roles, selected]) => ({ roles, selected }))
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _router: Router,
    private readonly _roleService: RoleService
  ) {
    super();
  }

  public handleSelect(role: Role) {
    if(role.roleId) {
      this._router.navigate(["/","workspace","roles","edit", role.roleId]);
    } else {
      this._router.navigate(["/","workspace","roles","create"]);
    }
  }

  public handleSave(role: Role) {
    const obs$  = role.roleId ? this._roleService.update({ role }) : this._roleService.create({ role });
    obs$
    .pipe(
      takeUntil(this._destroyed$),
      tap(_ => this._router.navigate(["/","workspace","roles"])))
    .subscribe();
  }
}

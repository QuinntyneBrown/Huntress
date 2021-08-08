import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PrivilegeService, RoleService } from '@api';
import { BehaviorSubject, of, zip } from 'rxjs';
import { concatAll, groupBy, map, mergeMap, switchMap, tap, toArray } from 'rxjs/operators';


@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.scss']
})
export class RoleComponent {

  private readonly _refresh$: BehaviorSubject<void> = new BehaviorSubject(null);

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _roleService: RoleService,
    private readonly _privilegeService: PrivilegeService
  ) { }

  public handleAdd($event:any) {
    const privilege = $event;

    Object.assign(privilege, { roleId: this._activatedRoute.snapshot.params.id });

    this._privilegeService.create({ privilege })
    .pipe(
      tap(x => this._refresh$.next())
    )
    .subscribe();
  }

  public handleRemove($event:any) {
    this._privilegeService.remove({ privilege: $event })
    .pipe(
      tap(x => this._refresh$.next())
    )
    .subscribe();
  }

  public vm$ = this._refresh$
  .pipe(
    switchMap(_ => this._activatedRoute.paramMap),
    map(paramMap => paramMap.get("id")),
    switchMap(roleId => this._roleService.getById({ roleId })),
    switchMap(role => of(role.privileges).pipe(
      concatAll(),
      groupBy(privilege => privilege.aggregate, privilege => privilege),
      mergeMap(group => zip(of(group.key), group.pipe(toArray()))),
      toArray(),
      map(aggregatePrivileges => ({
        role,
        aggregatePrivileges
      }))
    ))
    );
}

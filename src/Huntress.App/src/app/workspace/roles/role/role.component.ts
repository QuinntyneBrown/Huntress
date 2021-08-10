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

  public aggregates: string[] = [
    "Customer",
    "Order",
    "Product",
    "User"
  ];

  public accessRights: number[] = [0,1,2,3,4];

  public vm$ = this._refresh$
  .pipe(
    switchMap(_ => this._activatedRoute.paramMap),
    map(paramMap => paramMap.get("id")),
    switchMap(roleId => this._roleService.getById({ roleId })),
    map(role => {
      for(var i = 0; i < this.aggregates.length; i++) {
        if(role.privileges.filter(x => x.aggregate == this.aggregates[i]).length < 1) {
          role.aggregatePrivileges.push({
            aggregate: this.aggregates[i],
            privileges: []
          });
        }
      }
      return role;
    }),
    map(role => ({ role }))
    );
}

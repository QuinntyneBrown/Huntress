import { ChangeDetectionStrategy, Component, ViewChild } from '@angular/core';
import { BehaviorSubject, combineLatest, Observable, of } from 'rxjs';
import { map, switchMap, takeUntil, tap } from 'rxjs/operators';
import { MatPaginator } from '@angular/material/paginator';
import { EntityDataSource } from '@shared';
import { RoleService, Role } from '@api';
import { Router } from '@angular/router';
import { Destroyable } from '@core';

@Component({
  selector: 'app-role-list',
  templateUrl: './role-list.component.html',
  styleUrls: ['./role-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RoleListComponent extends Destroyable {

  @ViewChild(MatPaginator) paginator: MatPaginator;

  private readonly _pageIndex$: BehaviorSubject<number> = new BehaviorSubject(0);
  private readonly _pageSize$: BehaviorSubject<number> = new BehaviorSubject(5);
  private readonly _dataSource: EntityDataSource<Role> = new EntityDataSource(this._roleService);

  public readonly vm$: Observable<{
    dataSource: EntityDataSource<Role>,
    columnsToDisplay: string[],
    length$: Observable<number>,
    pageNumber: number,
    pageSize: number
  }> = combineLatest([this._pageIndex$, this._pageSize$ ])
  .pipe(
    switchMap(([pageIndex,pageSize]) => combineLatest([
      of([
        'name',
        'edit'
      ]),
      of(pageIndex),
      of(pageSize)
    ])
    .pipe(
      map(([columnsToDisplay, pageNumber, pageSize]) => {

        this._dataSource.getPage({ pageIndex, pageSize });

        return {
          dataSource: this._dataSource,
          columnsToDisplay,
          length$: this._dataSource.length$,
          pageSize,
          pageNumber
        }
      })
    ))
  );

  constructor(
    private readonly _roleService: RoleService,
    private readonly _router: Router
  ) {
    super();
  }

  public edit(role: Role) {
    this._router.navigate(['/','workspace','roles','edit',role.roleId ])
  }

  public create() {
    this._router.navigate(['/','workspace','roles','create'])
  }

  public delete(role: Role) {
    this._roleService.remove({ role }).pipe(
      takeUntil(this._destroyed$),
    ).subscribe();
  }
}

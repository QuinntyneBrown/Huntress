import { OverlayRef } from '@angular/cdk/overlay';
import { Component, EventEmitter, OnDestroy, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BehaviorSubject, combineLatest, Observable, Subject } from 'rxjs';
import { map, takeUntil, tap } from 'rxjs/operators';
import { Role, RoleService } from '@api';
import { Destroyable } from '@core';

@Component({
  selector: 'app-role-detail',
  templateUrl: './role-detail.component.html',
  styleUrls: ['./role-detail.component.scss']
})
export class RoleDetailComponent extends Destroyable implements OnDestroy {

  public role$: BehaviorSubject<Role> = new BehaviorSubject(null as any);

  @Output() public saved = new EventEmitter();

  public vm$ = combineLatest([
    this.role$
  ]).pipe(
    map(([role]) => {
      return {
        form: new FormGroup({
          role: new FormControl(role, [])
        })
      }
    })
  );

  constructor(
    private readonly _roleService: RoleService) {
      super();
  }

  public save(vm: { form: FormGroup}) {
    const role = vm.form.value.role;
    let obs$: Observable<{ role: Role }>;
    if(role.roleId) {
      obs$ = this._roleService.update({ role })
    }
    else {
      obs$ = this._roleService.create({ role })
    }

    obs$.pipe(
      takeUntil(this._destroyed$),
      tap(x => {
        this.saved.next(x.role);
      })
    ).subscribe();
  }

  public cancel() {

  }
}

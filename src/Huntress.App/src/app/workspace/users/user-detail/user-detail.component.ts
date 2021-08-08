import { OverlayRef } from '@angular/cdk/overlay';
import { Component, EventEmitter, OnDestroy, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BehaviorSubject, combineLatest, Observable, Subject } from 'rxjs';
import { map, takeUntil, tap } from 'rxjs/operators';
import { UserService, User } from '@api';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.scss']
})
export class UserDetailComponent implements OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();

  public user$: BehaviorSubject<User> = new BehaviorSubject(null as any);

  @Output() public saved = new EventEmitter();

  public vm$ = combineLatest([
    this.user$
  ]).pipe(
    map(([user]) => {
      return {
        form: new FormGroup({
          user: new FormControl(user, [])
        })
      }
    })
  )

  constructor(
    private readonly _overlayRef: OverlayRef,
    private readonly _userService: UserService) {     
  }

  public save(vm: { form: FormGroup}) {
    const user = vm.form.value.user;
    let obs$: Observable<{ user: User }>;
    if(user.userId) {
      obs$ = this._userService.update({ user })
    }   
    else {
      obs$ = this._userService.create({ user })
    } 

    obs$.pipe(
      takeUntil(this._destroyed),      
      tap(x => {
        this.saved.next(x.user);
        this._overlayRef.dispose();
      })
    ).subscribe();
  }

  public cancel() {
    this._overlayRef.dispose();
  }

  ngOnDestroy() {
    this._destroyed.complete();
    this._destroyed.next();
  }
}

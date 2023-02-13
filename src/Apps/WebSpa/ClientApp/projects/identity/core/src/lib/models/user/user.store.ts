import { Injectable } from "@angular/core";
import { ComponentStore } from "@ngrx/component-store";
import { catchError, EMPTY, first, mergeMap, Observable, of, shareReplay, switchMap, tap } from "rxjs";
import { User } from "./user";
import { UserService } from "./user.service";

export interface UserStoreState {
    currentUser?: User
}

@Injectable({
    providedIn: "root"
})
export class UserStore extends ComponentStore<UserStoreState> {
    constructor(
        private readonly _userService: UserService
    ) {
        super({ });        
    }

    public getCurrent(): Observable<User | undefined> {
        return of(undefined)
        .pipe(
          tap(_ => this._getCurrentUser()),
          switchMap(_ => this.select(x => x.currentUser))
        )
      }
    
      private readonly _getCurrentUser = this.effect<void>(trigger$ =>
        trigger$.pipe(
          switchMap(_ => this.select(x => x.currentUser).pipe(first())
          .pipe(
            switchMap(currentUser => {
              if(currentUser === undefined) {
                return this._userService.getCurrent()
                .pipe(
                  tap(currentUser => this.setState((state) => ({...state, currentUser }))),
                );
              }
              return of(currentUser);
            }),
          )),
          shareReplay(1)
        ));
    
      readonly update = this.effect<User>(user$ => user$.pipe(
        mergeMap(user => {
          return this._userService.update({ user })
          .pipe(
            tap({
              next: ({ user }) => {
                this.setState((state) => ({...state, currentUser: user }))
              },
              error: () => {
    
              }
            }),
            catchError(() => EMPTY)
          )
        })
      ));    
}
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { filter, finalize, shareReplay, startWith, switchMap, tap } from "rxjs/operators";
import { Dispatcher } from "./dispatcher";


@Injectable({
  providedIn: "root"
})
export class Cache {
  private readonly _inner: Map<string, Observable<any>> = new Map();
  private readonly _processing: Map<string, Observable<any>> = new Map();
  private readonly _invalidations: Map<string, string[]> = new Map();

  constructor(
    private readonly _dispatcher: Dispatcher
    ) {
    _dispatcher.invalidateStream$
      .pipe(
        tap(action => {
          let keys = this._invalidations.get(action);
          for (var i = 0; i < keys.length; i++) {
            this._inner.set(keys[i], null);
          }
          _dispatcher.emit(action, true);
        })
      )
      .subscribe();
  }

  public fromCacheOrService$(key: string, func: { (): Observable<any> }): Observable<any> {
    if (!this._inner.get(key)) {
      this._inner.set(key, func().pipe(shareReplay(1)));
    }
    return this._inner.get(key);
  }

  public fromCacheOrServiceWithRefresh$(key: string, func: any, token: string) {
    this.register(key, token);

    return this._dispatcher.refreshStream$.pipe(
      filter(action => action == action),
      startWith(token),
      switchMap(_ => {
        if (this._processing.get(key) != null) return this._processing.get(key);

        this._processing.set(key, this.fromCacheOrService$(key, func).pipe(finalize(() => this._processing.set(key, null))));

        return this._processing.get(key);
      })
    );
  }

  public register(key: string, token: string) {
    var keys = this._invalidations.get(token);
    keys = keys || [];
    if (keys.filter(x => x == key)[0] == null) {
      keys.push(key);
    }
    this._invalidations.set(token, keys);
  }
}

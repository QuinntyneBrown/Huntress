import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { shareReplay, switchMap, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class StatefulQueryService {

  private readonly _cache = new Map<string, Observable<any>>();

  private readonly _refreshSubject = new Subject<void>();

  protected _fromCacheOrService$(key:string, func: {(): Observable<any>}): Observable<any> {
    if (!this._cache.get(key)) {
      this._cache.set(
        key,
        func().pipe(shareReplay(1))
      );
    }
    return this._cache.get(key);
  }

  protected _fromCacheOrServiceWithRefresh$(key:string, func:any, refresh$: BehaviorSubject<void>) {
    return refresh$
    .pipe(
      tap(_ => this._cache.set(key,null)),
      switchMap(_ => this._fromCacheOrService$(key, func))
    );
  }
}

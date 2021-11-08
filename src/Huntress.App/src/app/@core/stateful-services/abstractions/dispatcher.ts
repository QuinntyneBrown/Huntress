import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";

@Injectable({
  providedIn:"root"
})
export class Dispatcher {
  private readonly _invalidateSubject: Subject<string> = new Subject();

  private readonly _refreshSubject: Subject<string> = new Subject();

  public invalidateStream$: Observable<string> = this._invalidateSubject.asObservable();

  public refreshStream$: Observable<string> = this._invalidateSubject.asObservable();

  public emit(action:string, refresh: boolean = false) {
    const subject = refresh ? this._refreshSubject : this._invalidateSubject;
    subject.next(action);
  }
}

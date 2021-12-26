import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CssVariable, CssVariableService } from '@api';
import { Destroyable } from '@core';
import { BehaviorSubject, combineLatest, of } from 'rxjs';
import { map, switchMap, takeUntil, tap } from 'rxjs/operators';


@Component({
  selector: 'or-css-variables',
  templateUrl: './css-variables.component.html',
  styleUrls: ['./css-variables.component.scss']
})
export class CssVariablesComponent extends Destroyable {

  private readonly _refreshSubject: BehaviorSubject<null> = new BehaviorSubject(null);

  readonly vm$ = this._refreshSubject
  .pipe(
    switchMap(_ => combineLatest([
      this._cssVariableService.get(),
      this._activatedRoute
      .paramMap
      .pipe(
        map(x => x.get("cssVariableId")),
        switchMap(cssVariableId => cssVariableId ? this._cssVariableService.getById({ cssVariableId }) : of({ }))
        )
    ])),
    map(([cssVariables, selected]) => ({ cssVariables, selected }))
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _router: Router,
    private readonly _cssVariableService: CssVariableService
  ) {
    super();
  }

  public handleSelect(cssVariable: CssVariable) {
    if(cssVariable.cssVariableId) {
      this._router.navigate(["/","workspace","css-variables","edit", cssVariable.cssVariableId]);
    } else {
      this._router.navigate(["/","workspace","css-variables","create"]);
    }
  }

  public handleSave(cssVariable: CssVariable) {
    const obs$  = cssVariable.cssVariableId ? this._cssVariableService.update({ cssVariable }) : this._cssVariableService.create({ cssVariable });
    obs$
    .pipe(
      takeUntil(this._destroyed$),
      tap(_ => {
        this._refreshSubject.next(null);
        this._router.navigate(["/","workspace","css-variables"]);
      }))
    .subscribe();
  }
}

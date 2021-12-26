import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Content } from '@api';
import { Destroyable } from '@core';
import { ContentStore } from '@core/stores/content.store';
import { combineLatest, of } from 'rxjs';
import { map, switchMap, takeUntil, tap } from 'rxjs/operators';


@Component({
  selector: 'or-contents',
  templateUrl: './contents.component.html',
  styleUrls: ['./contents.component.scss']
})
export class ContentsComponent extends Destroyable {

  readonly vm$ = combineLatest([
    this._contentStore.get$(),
    this._activatedRoute
    .paramMap
    .pipe(
      map(p => p.get("contentId")),
      switchMap(contentId => contentId ? this._contentStore.getById({ contentId }) : of({ }))
      )
  ])
  .pipe(
    map(([contents, selected]) => ({ contents, selected }))
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _router: Router,
    private readonly _contentStore: ContentStore
  ) {
    super();
  }

  public handleSelect(content: Content) {
    if(content.contentId) {
      this._router.navigate(["/","workspace","contents","edit", content.contentId]);
    } else {
      this._router.navigate(["/","workspace","contents","create"]);
    }
  }

  public handleSave(content: Content) {
    const obs$  = content.contentId ? this._contentStore.update$(content) : this._contentStore.create$(content);
    obs$
    .pipe(
      takeUntil(this._destroyed$),
      tap(_ => this._router.navigate(["/","workspace","contents"])))
    .subscribe();
  }
}

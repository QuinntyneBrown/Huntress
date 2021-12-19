import { CommonModule } from '@angular/common';
import { Directive, ElementRef, NgModule } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Destroyable } from '@core';
import { map, takeUntil, tap } from 'rxjs/operators';

const listViewCssClass = 'or-list-detail-container--list-view';

@Directive({
  selector: '[orListDetail]',
  host: {
    class: 'or-list-detail-container'
  }
})
export class ListDetailDirective extends Destroyable {

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _elementRef: ElementRef<HTMLElement>
  ) {
    super();

    this._activatedRoute.url
    .pipe(
      takeUntil(this._destroyed$),
      map(url => url.length == 0),
      tap(listView => {

        if(listView && !this._elementRef.nativeElement.classList.contains(listViewCssClass)) {
          this._elementRef.nativeElement.classList.add(listViewCssClass);
        }

        if(!listView) {
          this._elementRef.nativeElement.classList.remove(listViewCssClass)
        }
      })
      ).subscribe();
  }

}

@NgModule({
  declarations: [
    ListDetailDirective
  ],
  exports: [
    ListDetailDirective
  ],
  imports: [
    CommonModule,
    RouterModule
  ]
})
export class ListDetailModule { }

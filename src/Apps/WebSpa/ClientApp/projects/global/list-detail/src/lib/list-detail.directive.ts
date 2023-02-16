import { Directive, ElementRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Destroyable } from '@global/core';
import { map, takeUntil, tap } from 'rxjs';

const listViewCssClass = 'g-list-detail-container--list-view';

@Directive({
  selector: '[gListDetail]',
  standalone: true
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

import { Component } from '@angular/core';
import { ActivatedRoute, UrlSegment } from '@angular/router';
import { HtmlContentService } from '@api';
import { HtmlContentType } from '@api/models/html-content-type';
import { forkJoin, Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  public get isPublic$(): Observable<boolean> {
    return this._activatedRoute.firstChild?.url.pipe(
      map(urlSegments => urlSegments.map(x => x.path).indexOf("workspace") == -1)
    )
  }

  public vm$: Observable<{  }> = forkJoin([
    this._htmlContentService.getByType({ htmlContentType: HtmlContentType.About }),
    this._htmlContentService.getByType({ htmlContentType: HtmlContentType.Contact }),
    this._htmlContentService.getByType({ htmlContentType: HtmlContentType.FollowUs }),
    this._htmlContentService.getByType({ htmlContentType: HtmlContentType.ReturnPolicy }),

  ])
  .pipe(
    map(([about, contact, followUs, returnPolicy ]) =>
    ({ about, contact, followUs, returnPolicy }))
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _htmlContentService: HtmlContentService
  ) { }


}

import { Component } from '@angular/core';
import { ActivatedRoute} from '@angular/router';
import { HtmlContent, HtmlContentService, SocialShareService } from '@api';
import { HtmlContentType } from '@api/models/html-content-type';
import { forkJoin, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

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

  public vm$: Observable<{ about: HtmlContent }> = forkJoin([
    this._htmlContentService.getByType({ htmlContentType: HtmlContentType.About }),
    this._htmlContentService.getByType({ htmlContentType: HtmlContentType.Contact }),
    this._htmlContentService.getByType({ htmlContentType: HtmlContentType.FollowUs }),
    this._htmlContentService.getByType({ htmlContentType: HtmlContentType.ReturnPolicy }),
    this._socialShareService.get()
  ])
  .pipe(
    map(([about, contact, followUs, returnPolicy, socials ]) =>
    ({ about, contact, followUs, returnPolicy, socials }))
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _socialShareService: SocialShareService,
    private readonly _htmlContentService: HtmlContentService
  ) { }


}

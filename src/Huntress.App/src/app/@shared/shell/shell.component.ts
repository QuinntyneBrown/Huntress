import { DOCUMENT } from '@angular/common';
import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CssVariableService, HtmlContent, HtmlContentService, HtmlContentType, SocialShareService } from '@api';
import { NavigationService } from '@core';
import { forkJoin, Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';



@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.scss']
})
export class ShellComponent {


  public setCssVariables$ = this._cssVariableService.get()
  .pipe(
    tap(cssVariables => {
      for(var i = 0; i < cssVariables.length; i++) {
        this._document.body.style.setProperty(cssVariables[i].name,cssVariables[i].value)
      }
    })
  )

  public vm$: Observable<{ about: HtmlContent }> = forkJoin([
    this._htmlContentService.getByType({ htmlContentType: HtmlContentType.About }),
    this._htmlContentService.getByType({ htmlContentType: HtmlContentType.Contact }),
    this._htmlContentService.getByType({ htmlContentType: HtmlContentType.FollowUs }),
    this._htmlContentService.getByType({ htmlContentType: HtmlContentType.ReturnPolicy }),
    this._socialShareService.get(),
    this.setCssVariables$
  ])
  .pipe(
    map(([about, contact, followUs, returnPolicy, socials ]) =>
    ({ about, contact, followUs, returnPolicy, socials }))
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _socialShareService: SocialShareService,
    private readonly _htmlContentService: HtmlContentService,
    private readonly _cssVariableService: CssVariableService,
    private readonly _navigationService: NavigationService,
    @Inject(DOCUMENT) private readonly _document: Document,
    private readonly _changeDetectorRef: ChangeDetectorRef
  ) { }

  public handleTitleClick() {
    this._navigationService.redirectToPublicDefault();
  }
}

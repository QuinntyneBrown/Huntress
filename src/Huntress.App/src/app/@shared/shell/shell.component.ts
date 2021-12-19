import { DOCUMENT } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { CssVariableService, SocialShareService } from '@api';
import { NavigationService } from '@core';
import { ContentStore } from '@core/stores';
import { combineLatest, Observable } from 'rxjs';
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

  public vm$: Observable<any> = combineLatest([
    this._contentStore.getByName({ name: 'shell'}),
    this._socialShareService.get(),
    this.setCssVariables$
  ])
  .pipe(
    map(([content,socials]) => {
      return {
      about: content.json.about,
      contact: content.json.contact,
      followUs: content.json.followUs,
      returnPolicy: content.json.returnPolicy,
      socials
      };
    })
  );

  constructor(
    private readonly _socialShareService: SocialShareService,
    private readonly _contentStore: ContentStore,
    private readonly _cssVariableService: CssVariableService,
    private readonly _navigationService: NavigationService,
    @Inject(DOCUMENT) private readonly _document: Document
  ) { }

  public handleTitleClick() {
    this._navigationService.redirectToPublicDefault();
  }
}

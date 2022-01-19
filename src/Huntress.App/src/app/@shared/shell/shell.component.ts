import { DOCUMENT } from '@angular/common';
import { Component, ComponentFactoryResolver, Inject, TemplateRef, ViewChild, ViewContainerRef } from '@angular/core';
import { CssVariableService, SocialShareService } from '@api';
import { combine, NavigationService } from '@core';
import { ContentStore } from '@core/stores';
import { CartService } from '@shared/components/cart/cart.service';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';


@Component({
  selector: 'or-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.scss']
})
export class ShellComponent  {

  readonly opened$ = this._cartService.opened$;
  
  @ViewChild(TemplateRef, { read: ViewContainerRef, static: true }) viewContainerRef: ViewContainerRef;

  setCssVariables$ = this._cssVariableService.get()
  .pipe(
    tap(cssVariables => {
      for(var i = 0; i < cssVariables.length; i++) {
        this._document.body.style.setProperty(cssVariables[i].name,cssVariables[i].value)
      }
    })
  )

  readonly vm$: Observable<any> = combine([
    this._contentStore.getByName$({ name: 'shell'}),
    this._socialShareService.get(),
    this.setCssVariables$,
  ])
  .pipe(
    map(([content, socials, _]) => {
      
      return {
      about: content?.json?.about,
      contact: content?.json?.contact,
      followUs: content?.json?.followUs,
      returnPolicy: content?.json?.returnPolicy,
      socials
      };
    })
  );

  constructor(
    private readonly _cartService: CartService,
    private readonly _socialShareService: SocialShareService,
    private readonly _contentStore: ContentStore,
    private readonly _cssVariableService: CssVariableService,
    private readonly _navigationService: NavigationService,
    @Inject(DOCUMENT) private readonly _document: Document
  ) { }

  handleTitleClick() {
    this._navigationService.redirectToPublicDefault();
  }
}

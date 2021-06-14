import { Component, Input, OnInit } from '@angular/core';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

@Component({
  selector: 'app-html-content-section',
  templateUrl: './html-content-section.component.html',
  styleUrls: ['./html-content-section.component.scss']
})
export class HtmlContentSectionComponent {

  @Input("html") private _html:string | undefined;

  public get html(): SafeHtml { return this._domSanitizer.bypassSecurityTrustHtml(this._html); }

  public xhtml: SafeHtml = this._domSanitizer.bypassSecurityTrustHtml("<h1>Wtf</h1>");

  @Input() public title: string | undefined;

  constructor(
    private readonly _domSanitizer: DomSanitizer
  ) {

  }

}

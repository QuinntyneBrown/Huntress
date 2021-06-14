import { Component, Input, OnInit } from '@angular/core';
import { HtmlContentService } from '@api';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent  {


  @Input() public aboutHtmlContent: string | undefined;

  @Input() public followUsHtmlContent: string | undefined;

  @Input() public returnPolicyHtmlContent: string | undefined;

  @Input() public contactHtmlContent: string | undefined;

  constructor(
    private readonly _htmlContentService: HtmlContentService
  ) { }


}

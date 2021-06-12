import { Component, OnInit } from '@angular/core';
import { HtmlContentService } from '@api';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent  {

  constructor(
    private readonly _htmlContentService: HtmlContentService
  ) { }


}

import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-html-content-section',
  templateUrl: './html-content-section.component.html',
  styleUrls: ['./html-content-section.component.scss']
})
export class HtmlContentSectionComponent {

  @Input() public html: string | undefined;

  @Input() public title: string | undefined;

}

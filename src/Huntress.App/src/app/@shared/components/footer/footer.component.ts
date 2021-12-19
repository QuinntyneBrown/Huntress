import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent  {
  @Input() public aboutHtmlContent: string;

  @Input() public followUsHtmlContent: string | undefined;

  @Input() public returnPolicyHtmlContent: string | undefined;

  @Input() public contactHtmlContent: string | undefined;
}

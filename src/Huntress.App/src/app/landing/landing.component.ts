import { Component, Inject, OnInit } from '@angular/core';
import { ImageContent, ImageContentType } from '@api';
import { ImageContentService } from '@api/services';
import { baseUrl } from '@core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.scss']
})
export class LandingComponent implements OnInit {

  public vm$: Observable<{ heroUrl: string}> = this._imageContentService
  .getByType({ imageContentType: ImageContentType.Hero })
  .pipe(
    map( imageContent => ({ heroUrl: `url(${this._baseUrl}${imageContent.url})` }))
  );

  constructor(
    private readonly _imageContentService: ImageContentService,
    @Inject(baseUrl) private readonly _baseUrl: string
  ) { }

  ngOnInit(): void {
  }

}

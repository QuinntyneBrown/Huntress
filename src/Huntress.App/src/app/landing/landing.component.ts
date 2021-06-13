import { Component, Inject } from '@angular/core';
import { ImageContentType, Product } from '@api';
import { HtmlContentType } from '@api/models/html-content-type';
import { HtmlContentService, ImageContentService, ProductService } from '@api/services';
import { baseUrl } from '@core';
import { forkJoin, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.scss']
})
export class LandingComponent {

  public vm$: Observable<{ heroUrl: string, products: Product[] }> = forkJoin([
    this._imageContentService.getByType({ imageContentType: ImageContentType.Hero }),
    this._productService.get(),
    this._htmlContentService.getByType({ htmlContentType: HtmlContentType.About }),
    this._htmlContentService.getByType({ htmlContentType: HtmlContentType.Contact }),
    this._htmlContentService.getByType({ htmlContentType: HtmlContentType.FollowUs }),
    this._htmlContentService.getByType({ htmlContentType: HtmlContentType.ReturnPolicy }),

  ])
  .pipe(
    map(([imageContent, products, about, contact, followUs, returnPolicy ]) =>
    ({ heroUrl: `url(${this._baseUrl}${imageContent.url})`, products, about, contact, followUs, returnPolicy }))
  );

  constructor(
    private readonly _imageContentService: ImageContentService,
    private readonly _productService: ProductService,
    private readonly _htmlContentService: HtmlContentService,
    @Inject(baseUrl) private readonly _baseUrl: string
  ) { }

}

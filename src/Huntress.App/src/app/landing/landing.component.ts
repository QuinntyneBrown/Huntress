import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { ImageContentType, Product } from '@api';
import { ImageContentService, ProductService } from '@api/services';
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
    this._productService.get()

  ])
  .pipe(
    map(([imageContent, products ]) =>
    ({ heroUrl: `url(${this._baseUrl}${imageContent.url})`, products }))
  );

  constructor(
    private readonly _imageContentService: ImageContentService,
    private readonly _productService: ProductService,
    private readonly _router: Router,
    @Inject(baseUrl) private readonly _baseUrl: string
  ) { }

  public handleProductClick(product: Product) {
    this._router.navigate(['products', product.productId]);
  }
}

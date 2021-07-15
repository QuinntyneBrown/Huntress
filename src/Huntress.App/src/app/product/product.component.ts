import { Component, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '@api';
import { baseUrl } from '@core';
import { map, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent {

  public readonly vm$ = this._activatedRoute.paramMap
  .pipe(
    map(paramMap => paramMap.get("productId")),
    switchMap(productId => this._productService.getById({ productId })),
    map(product => {
      return {
        product: Object.assign(product, {imageUrl:`${this._baseUrl}${product.productImages[0].imageUrl}`})
      }
    })
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _productService: ProductService,
    @Inject(baseUrl) private readonly _baseUrl: string
  ) {

  }
}

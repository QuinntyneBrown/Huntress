import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from '@api';
import { ProductService } from '@api/services';
import { baseUrl } from '@core';
import { ContentStore } from '@core/stores';
import { forkJoin, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.scss']
})
export class LandingComponent {

  public vm$: Observable<{ heroUrl: string, products: Product[] }> = forkJoin([
    this._contentStore.getByName({ name: 'landing' }),
    this._productService.get()

  ])
  .pipe(
    map(([content, products ]) => {
      return { heroUrl: `url(${this._baseUrl}${content.json.heroUrl})`, products };
    }
    )
  );

  constructor(
    private readonly _contentStore: ContentStore,
    private readonly _productService: ProductService,
    private readonly _router: Router,
    @Inject(baseUrl) private readonly _baseUrl: string
  ) { }

  public handleProductClick(product: Product) {
    this._router.navigate(['products', product.productId]);
  }
}

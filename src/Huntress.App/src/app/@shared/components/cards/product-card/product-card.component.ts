import { Component, Inject, Input } from '@angular/core';
import { Product } from '@api';
import { BASE_URL } from '@core';


@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss']
})
export class ProductCardComponent {

  @Input() public product: Product | undefined;

  public get imageUrl() {
    return `${this._baseUrl}${this.product.productImages[0].imageUrl}`;
  }

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string
  ) {

  }
}

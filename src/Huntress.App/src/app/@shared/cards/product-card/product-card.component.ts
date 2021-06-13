import { Component, Input } from '@angular/core';
import { Product } from '@api';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss']
})
export class ProductCardComponent {

  @Input() public product: Product | undefined;
}

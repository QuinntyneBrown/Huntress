import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Product } from '@api';

@Component({
  selector: 'app-products-section',
  templateUrl: './products-section.component.html',
  styleUrls: ['./products-section.component.scss']
})
export class ProductsSectionComponent {

  @Input() public products: Product[] = [];

  @Output() public readonly productClick: EventEmitter<Product> = new EventEmitter();

}

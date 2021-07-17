import { Injectable } from '@angular/core';
import { Product } from '@api';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  public products$: BehaviorSubject<Product[]> = new BehaviorSubject([]);

  public addProduct(product: Product) {
    const products = this.products$.value;
    products.push(product);
    this.products$.next(products);
  }
}

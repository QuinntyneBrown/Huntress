import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BehaviorSubject, combineLatest, Observable } from 'rxjs';
import { map, takeUntil, tap } from 'rxjs/operators';
import { ProductService, Product } from '@api';
import { Destroyable } from '@core/destroyable';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent extends Destroyable {

  public product$: BehaviorSubject<Product> = new BehaviorSubject(null as any);

  @Output() public saved = new EventEmitter();

  public vm$ = combineLatest([
    this.product$
  ]).pipe(
    map(([product]) => {
      return {
        form: new FormGroup({
          product: new FormControl(product, [])
        })
      }
    })
  )

  constructor(
    private readonly _productService: ProductService) {
      super();
  }

  public save(vm: { form: FormGroup}) {
    const product = vm.form.value.product;
    let obs$: Observable<{ product: Product }>;
    if(product.productId) {
      obs$ = this._productService.update({ product })
    }
    else {
      obs$ = this._productService.create({ product })
    }

    obs$.pipe(
      takeUntil(this._destroyed$),
      tap(x => {
        this.saved.next(x.product);
      })
    ).subscribe();
  }

  public cancel() {

  }
}

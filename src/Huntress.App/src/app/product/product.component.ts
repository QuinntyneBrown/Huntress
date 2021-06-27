import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '@api';
import { map, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent {

  public readonly vm$ = this._activatedRoute.paramMap
  .pipe(
    map(paramMap => paramMap.get("name")),
    switchMap(name => this._productService.getByName({ name })),
    map(product => ({ product }))
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _productService: ProductService
  ) {

  }

}

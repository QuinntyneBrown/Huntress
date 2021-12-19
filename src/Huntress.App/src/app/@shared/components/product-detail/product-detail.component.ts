import { Component, EventEmitter, Input, NgModule, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { Product } from '@api';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'or-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent {

  readonly form: FormGroup = new FormGroup({
    productId: new FormControl(null, []),
    name: new FormControl(null, [Validators.required])
  });

  public get product(): Product { return this.form.value as Product; }

  @Input("product") public set product(value: Product) {
    if(!value?.productId) {
      this.form.reset({
        name: null
      })
    } else {
      this.form.patchValue(value);
    }
  }

  @Output() save: EventEmitter<Product> = new EventEmitter();

}

@NgModule({
  declarations: [
    ProductDetailComponent
  ],
  exports: [
    ProductDetailComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    ReactiveFormsModule
  ]
})
export class ProductDetailModule { }

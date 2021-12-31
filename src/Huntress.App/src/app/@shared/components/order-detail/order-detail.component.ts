import { Component, EventEmitter, Input, NgModule, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { Order } from '@api';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'or-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.scss']
})
export class OrderDetailComponent {

  readonly form: FormGroup = new FormGroup({
    orderId: new FormControl(null, []),
    name: new FormControl(null, [Validators.required])
  });

  get order(): Order { return this.form.value as Order; }

  @Input("order") set order(value: Order) {
    if(!value?.orderId) {
      this.form.reset({
        name: null
      })
    } else {
      this.form.patchValue(value);
    }
  }

  @Output() save: EventEmitter<Order> = new EventEmitter();

}

@NgModule({
  declarations: [
    OrderDetailComponent
  ],
  exports: [
    OrderDetailComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    ReactiveFormsModule
  ]
})
export class OrderDetailModule { }

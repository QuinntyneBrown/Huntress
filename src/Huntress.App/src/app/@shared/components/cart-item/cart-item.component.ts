import { Component, forwardRef, Input, NgModule } from '@angular/core';
import { AbstractControl, FormControl, NG_VALIDATORS, NG_VALUE_ACCESSOR, ReactiveFormsModule, ValidationErrors, Validator, Validators } from '@angular/forms';
import { takeUntil,} from 'rxjs/operators';
import { BaseControl } from '@core';
import { CommonModule } from '@angular/common';
import { QuantityModule } from '../quantity';



@Component({
  selector: 'or-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => CartItemComponent),
      multi: true
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => CartItemComponent),
      multi: true
    }
  ]
})
export class CartItemComponent extends BaseControl implements Validator {

  readonly formControl = new FormControl(null,[Validators.required]);

  @Input() name: string;

  validate(control: AbstractControl): ValidationErrors | null {
      return this.formControl.errors;
  }

  writeValue(obj: any): void {
    this.formControl.setValue(obj, { emitEvent: false });
  }

  registerOnChange(fn: any): void {
    this.formControl.valueChanges
    .pipe(
      takeUntil(this._destroyed$)
    )
    .subscribe(fn);
  }
}
@NgModule({
  declarations: [
    CartItemComponent
  ],
  exports: [
    CartItemComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    QuantityModule
  ]
})
export class CartItemModule { }

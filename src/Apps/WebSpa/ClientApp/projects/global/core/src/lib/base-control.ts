import { Injectable } from '@angular/core';
import { Destroyable } from './destroyable';
import { ControlValueAccessor } from '@angular/forms';

@Injectable()
export abstract class BaseControl extends Destroyable implements ControlValueAccessor {

  abstract writeValue(obj: any): void;

  abstract registerOnChange(fn: any): void;

  registerOnTouched(fn: any): void {

  }

  setDisabledState?(isDisabled: boolean): void {

  }

}
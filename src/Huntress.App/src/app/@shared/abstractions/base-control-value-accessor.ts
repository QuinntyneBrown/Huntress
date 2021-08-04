import { ElementRef, Injectable, OnDestroy } from "@angular/core";
import { AbstractControl, ControlValueAccessor } from "@angular/forms";
import { Subject } from "rxjs";

@Injectable()
export abstract class BaseControlValueAccessor implements ControlValueAccessor, OnDestroy {

  private readonly _destroyed$ = new Subject();

  private control!: AbstractControl;

  constructor(
    private readonly _elementRef: ElementRef
  ) {

  }
  writeValue(obj: any): void {

  }

  registerOnChange(fn: any): void {

  }

  registerOnTouched(fn: any): void {

  }

  setDisabledState?(isDisabled: boolean): void {

  }

  ngOnDestroy() {
    this._destroyed$.next(null);
    this._destroyed$.complete();
  }

}

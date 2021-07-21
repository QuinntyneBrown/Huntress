import { OverlayRef } from '@angular/cdk/overlay';
import { Component } from '@angular/core';
import { FormArray, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { map } from 'rxjs/operators';
import { CartService } from './cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent {

  public formArray$ = this._cartService.products$
  .pipe(
    map(products => {
      const controls = products.map(x => new FormControl(x));

      return new FormArray(controls);
    })
  )

  constructor(
    private readonly _cartService: CartService,
    private readonly _overlayRef: OverlayRef,
    private readonly _router: Router
  ) {

  }

  public close() {

  }

  public checkout$: Subject<void> = new Subject();

  public close$: Subject<void> = new Subject();
}

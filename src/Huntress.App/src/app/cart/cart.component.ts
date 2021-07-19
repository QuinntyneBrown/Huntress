import { OverlayRef } from '@angular/cdk/overlay';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { CartService } from './cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent {

  public readonly products$ = this._cartService.products$;

  constructor(
    private readonly _cartService: CartService,
    private readonly _overlayRef: OverlayRef,
    private readonly _router: Router
  ) {

  }

  public close() {

  }

  public checkout$: Subject<void> = new Subject();
}

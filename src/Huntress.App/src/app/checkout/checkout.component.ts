import { Component } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'or-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent {

  readonly vm$ = of({ })
  .pipe(
    map(model => ({ model }))
  );

  constructor(

  ) {

  }
}

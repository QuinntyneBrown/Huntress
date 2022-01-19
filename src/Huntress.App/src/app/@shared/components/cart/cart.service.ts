import { Injectable } from '@angular/core';
import { Product } from '@api';
import { queryStore } from '@quinntyne/query-store';
import { BehaviorSubject, Observable, of, Subject } from 'rxjs';

export class CartStore extends queryStore(class { }) {

}

@Injectable({
  providedIn: 'root'
})
export class CartService {

  productsSubject = new BehaviorSubject([]);

  openedSubject: Subject<boolean> = new Subject();

  opened$ = this.openedSubject.asObservable();

  open() {
    this.openedSubject.next(true);
  }

  close() {
    this.openedSubject.next(false);
  }

  readonly products$ = this.productsSubject.asObservable();

  addProduct(product: Product): Observable<boolean> {
    return of(true);
  }

  removeProduct(prodduct: Product) {

  }

  constructor() { }
}

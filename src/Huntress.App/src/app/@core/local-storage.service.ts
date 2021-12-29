import { Injectable } from '@angular/core';
import { storageKey } from './constants';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {
  private _items?: any[] | null | undefined = null;

  get items(): any[] | null | undefined {
    if (this._items === null) {
      let storageItems = localStorage.getItem(storageKey);
      if (storageItems === 'null') {
        storageItems = null;
      }
      this._items = JSON.parse(storageItems || '[]');
    }
    return this._items;
  }

  set items(value: Array<any> | null | undefined) {
    this._items = value;
  }

  get = (options: { name: string }) => {
    let storageItem = null;

    if(!this.items)
      return null;

    for (const item of this.items) {
      if (options.name === item.name) { storageItem = item.value; }
    }

    return storageItem;
  }

  put = (options: { name: string; value: any }) => {
    let itemExists = false;

    if(!this.items)
      return;

    this.items.forEach((item: any) => {
      if (options.name === item.name) {
        itemExists = true;
        item.value = options.value;
      }
    });

    if (!itemExists) {
      let items: any[] | null = this.items;
      items.push({ name: options.name, value: options.value });
      this.items = items;
      items = null;
    }

    this.updateLocalStorage();
  };

  updateLocalStorage(): void {
    localStorage.setItem(storageKey, JSON.stringify(this._items));
  }
}

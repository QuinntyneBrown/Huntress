// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Injectable, Inject } from '@angular/core';
import { STORAGE_KEY } from './constants';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {
  private _items?: any[] | null | undefined = null;

  constructor(
    @Inject(STORAGE_KEY) private readonly _storageKey:string
  ) {

  }

  public get items(): any[] | null | undefined {
    if (this._items === null) {
      let storageItems = localStorage.getItem(this._storageKey);
      if (storageItems === 'null') {
        storageItems = null;
      }
      this._items = JSON.parse(storageItems || '[]');
    }
    return this._items;
  }

  public set items(value: Array<any> | null | undefined) {
    this._items = value;
  }

  public get = (options: { name: string }) => {
    let storageItem = null;
    
    if(!this.items)
      return null;

    for (const item of this.items) {
      if (options.name === item.name) { 
        storageItem = item.value;
        break; 
      }
    }

    return storageItem;
  }

  public put = (options: { name: string; value: any }) => {
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
  
  public updateLocalStorage(): void {
    localStorage.setItem(this._storageKey, JSON.stringify(this._items));
  }
}


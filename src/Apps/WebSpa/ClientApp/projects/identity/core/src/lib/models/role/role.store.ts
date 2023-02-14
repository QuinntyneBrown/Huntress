// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Injectable } from "@angular/core";
import { ComponentStore } from "@ngrx/component-store";
import { EMPTY, merge, of, Subject } from "rxjs";
import { catchError, filter, first, mergeMap, shareReplay, switchMap, tap } from "rxjs/operators";
import { Role } from "./role";
import { RoleService } from "./role.service";

export interface RoleStoreState {

}

@Injectable({
  providedIn: "root"
})
export class ToDoStore extends ComponentStore<RoleStoreState> {

  private readonly _refresh$: Subject<void> = new Subject();

  constructor(
    private readonly _roleService: RoleService
  ) {
    super({ })
  }

}

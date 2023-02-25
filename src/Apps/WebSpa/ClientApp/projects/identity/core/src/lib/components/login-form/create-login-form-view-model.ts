// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { inject } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { AuthService } from "@identity/core";
import { map,of, Subject } from "rxjs";

export function createLoginFormViewModel() {

  const form = new FormGroup({
    username: new FormControl("quinntynebrown@gmail.com", [Validators.required]),
    password: new FormControl("P@ssw0rd", [Validators.required])
  });

  const tryToLoginSubject: Subject<{
    username: string,
    password: string
   }> = new Subject();

  const authService = inject(AuthService);

  return of(form).pipe(
    map(form => ({ form }))
  );
};



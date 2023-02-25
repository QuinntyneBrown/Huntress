// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { inject } from "@angular/core";
import { AuthService, RedirectService } from "@identity/core";
import { tap } from "rxjs";

export function createViewModel() {
  const authService = inject(AuthService);
  const redirectService = inject(RedirectService);

  return authService.currentUser$.pipe(
    tap(user => {
      if(user)
        redirectService.redirectPreLogin();
    })
  );
}

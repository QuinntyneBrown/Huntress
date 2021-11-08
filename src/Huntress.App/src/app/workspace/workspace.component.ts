import { Component, OnInit, ViewChild } from '@angular/core';
import { BreakpointObserver } from '@angular/cdk/layout';
import { MatDrawer } from '@angular/material/sidenav';

import { AuthService, Destroyable, NavigationService } from '@core';
import { NavigationEnd, Router } from '@angular/router';
import { filter, takeUntil, tap } from 'rxjs/operators';


@Component({
  selector: 'app-workspace',
  templateUrl: './workspace.component.html',
  styleUrls: ['./workspace.component.scss']
})
export class WorkspaceComponent extends Destroyable implements OnInit {

  constructor(
    public breakpointObserver: BreakpointObserver,
    private readonly _authService: AuthService,
    private readonly _navigationService: NavigationService,
    private readonly _router: Router
  ) {
    super();
  }

  @ViewChild(MatDrawer, { static: true }) public drawer: MatDrawer | undefined;

  public handleLogoutClick() {
    this._authService.logout();
    this._navigationService.redirectToPublicDefault();
  }

  public ngOnInit() {
    this._router.events
      .pipe(
        takeUntil(this._destroyed$),
        filter(e => e instanceof NavigationEnd),
        tap(x => {
          this.drawer.close();
        })
      )
      .subscribe();
  }

  public handleSidenavMenuClick() {
    this.drawer.open();
  }

  public handleSidenavCloseClick() {
    this.drawer.close();
  }
}

import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { AuthService, Destroyable, NavigationService } from '@core';
import { NavigationEnd, Router } from '@angular/router';
import { filter, takeUntil, tap } from 'rxjs/operators';


@Component({
  selector: 'or-workspace',
  templateUrl: './workspace.component.html',
  styleUrls: ['./workspace.component.scss']
})
export class WorkspaceComponent extends Destroyable implements OnInit {

  constructor(
    private readonly _authService: AuthService,
    private readonly _navigationService: NavigationService,
    private readonly _router: Router
  ) {
    super();
  }

  @ViewChild("drawer", { static: true }) public drawer: MatDrawer | undefined;

  handleLogoutClick() {
    this._authService.logout();
    this._navigationService.redirectToPublicDefault();
  }

  handleTitleClick() {
    this._navigationService.redirectToPublicDefault();
  }

  ngOnInit() {
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

import { Component, OnInit, ViewChild } from '@angular/core';
import { BreakpointObserver } from '@angular/cdk/layout';
import { filter, map, tap } from 'rxjs/operators';
import { MatDrawer } from '@angular/material/sidenav';
import { merge } from 'rxjs';
import { NavigationEnd, Router } from '@angular/router';
import { AuthService, NavigationService } from '@core';


@Component({
  selector: 'app-workspace',
  templateUrl: './workspace.component.html',
  styleUrls: ['./workspace.component.scss']
})
export class WorkspaceComponent {

  constructor(
    public breakpointObserver: BreakpointObserver,
    private readonly _authService: AuthService,
    private readonly _navigationService: NavigationService
  ) { }

  public handleLogoutClick() {
    this._authService.logout();
    this._navigationService.redirectToPublicDefault();
  }

}

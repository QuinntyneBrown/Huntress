import { Component, OnInit, ViewChild } from '@angular/core';
import { BreakpointObserver } from '@angular/cdk/layout';
import { filter, map, tap } from 'rxjs/operators';
import { MatDrawer } from '@angular/material/sidenav';
import { merge } from 'rxjs';
import { NavigationEnd, Router } from '@angular/router';


@Component({
  selector: 'app-workspace',
  templateUrl: './workspace.component.html',
  styleUrls: ['./workspace.component.scss']
})
export class WorkspaceComponent implements OnInit {

  private readonly _desktop$  = this.breakpointObserver.observe("(min-width: 992px)").
  pipe(
    filter(breakpointState => breakpointState.matches),
    tap(_ => this.drawer?.open()),
    map(_ => "side")
  )

  private readonly _mobile$  = this.breakpointObserver.observe("(max-width: 992px)").
  pipe(
    filter(breakpointState => breakpointState.matches),
    tap(_ => this.drawer?.close()),
    map(_ => "over")
  )

  public mode$ = merge(this._desktop$,this._mobile$);

  @ViewChild(MatDrawer, { static: true}) public drawer: MatDrawer | undefined;

  constructor(
    public breakpointObserver: BreakpointObserver,
    private readonly _router: Router
  ) { }

  ngOnInit() {
    this._router.events
    .pipe(
      filter(x => x instanceof NavigationEnd),
      tap(x => this.drawer?.close())
    ).subscribe();
  }


}

import { Component } from '@angular/core';
import { ActivatedRoute, UrlSegment } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  public get isPublic$(): Observable<boolean> {
    return this._activatedRoute.url.pipe(
      map(urlSegments => urlSegments.map(x => x.path).indexOf("workspace") == -1)
    )
  }

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
  ) { }


}

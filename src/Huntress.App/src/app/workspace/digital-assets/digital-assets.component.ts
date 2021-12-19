import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DigitalAsset, DigitalAssetService } from '@api';
import { Destroyable } from '@core';
import { combineLatest, of } from 'rxjs';
import { map, switchMap, takeUntil, tap } from 'rxjs/operators';


@Component({
  selector: 'or-digital-assets',
  templateUrl: './digital-assets.component.html',
  styleUrls: ['./digital-assets.component.scss']
})
export class DigitalAssetsComponent extends Destroyable {

  readonly vm$ = combineLatest([
    this._digitalAssetService.get(),
    this._activatedRoute
    .paramMap
    .pipe(
      map(p => p.get("digitalAssetId")),
      switchMap(digitalAssetId => digitalAssetId ? this._digitalAssetService.getById({ digitalAssetId }) : of({ }))
      )
  ])
  .pipe(
    map(([digitalAssets, selected]) => ({ digitalAssets, selected }))
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _router: Router,
    private readonly _digitalAssetService: DigitalAssetService
  ) {
    super();
  }

  public handleSelect(digitalAsset: DigitalAsset) {
    if(digitalAsset.digitalAssetId) {
      this._router.navigate(["/","workspace","digital-assets","edit", digitalAsset.digitalAssetId]);
    } else {
      this._router.navigate(["/","workspace","digital-assets","create"]);
    }
  }

  public handleSave(digitalAsset: DigitalAsset) {
    const obs$  = digitalAsset.digitalAssetId ? this._digitalAssetService.update({ digitalAsset }) : this._digitalAssetService.create({ digitalAsset });
    obs$
    .pipe(
      takeUntil(this._destroyed$),
      tap(_ => this._router.navigate(["/","workspace","digital-assets"])))
    .subscribe();
  }
}

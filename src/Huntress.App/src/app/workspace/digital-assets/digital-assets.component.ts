import { ChangeDetectionStrategy, Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DigitalAsset, DigitalAssetService } from '@api';
import { combine } from '@core';
import { BehaviorSubject, from, Observable, of, Subject } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';


@Component({
  selector: 'or-digital-assets',
  templateUrl: './digital-assets.component.html',
  styleUrls: ['./digital-assets.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DigitalAssetsComponent {

  private readonly _saveSubject: Subject<DigitalAsset> = new Subject();
  private readonly _selectSubject: Subject<DigitalAsset> = new Subject();
  private readonly _createSubject: Subject<void> = new Subject();
  private readonly _deleteSubject: Subject<DigitalAsset> = new Subject();
  private readonly _refreshSubject: BehaviorSubject<null> = new BehaviorSubject(null);

  readonly vm$ = this._refreshSubject
  .pipe(
    switchMap(_ => combine([
      this._digitalAssetService.get(),
      this._selected$,
      this._createSubject.pipe(switchMap(_ => this._handleCreate())),
      this._saveSubject.pipe(switchMap(digitalAsset => this._handleSave(digitalAsset))),
      this._selectSubject.pipe(switchMap(digitalAsset => this._handleSelect(digitalAsset))),
      this._deleteSubject.pipe(switchMap(digitalAsset => this._handleDelete(digitalAsset)))
    ])),
    map(([digitalAssets, selected]) => ({ digitalAssets, selected }))
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _digitalAssetService: DigitalAssetService,
    private readonly _router: Router,  
  ) { }

  private _handleSelect(digitalAsset: DigitalAsset): Observable<boolean> {
    return from(this._router.navigate(["/","workspace","digital-assets","edit", digitalAsset.digitalAssetId]));
  }

  private _handleCreate(): Observable<boolean> {
    return from(this._router.navigate(["/","workspace","digital-assets","create"]));
  }

  private _handleSave(digitalAsset: DigitalAsset): Observable<boolean> {
    return (digitalAsset.digitalAssetId ? this._digitalAssetService.update({ digitalAsset }) : this._digitalAssetService.create({ digitalAsset }))
    .pipe(      
      switchMap(_ => this._router.navigate(["/","workspace","digital-assets"])),
      tap(_ => this._refreshSubject.next(null))
      );    
  }

  private _handleDelete(digitalAsset: DigitalAsset): Observable<boolean> {
    return this._digitalAssetService.remove({ digitalAsset })
    .pipe(
      switchMap(_ => this._router.navigate(["/","workspace","digital-assets"])),
      tap(_ => this._refreshSubject.next(null))
    );
  }

  private _selected$: Observable<DigitalAsset> = this._activatedRoute
  .paramMap
  .pipe(
    map(x => x.get("digitalAssetId")),
    switchMap((digitalAssetId: string) => digitalAssetId ? this._digitalAssetService.getById({ digitalAssetId }) : of({} as DigitalAsset)));

  onSave(digitalAsset: DigitalAsset) {
    this._saveSubject.next(digitalAsset);
  }

  onSelect(digitalAsset: DigitalAsset) {
    this._selectSubject.next(digitalAsset);
  }

  onCreate() {
    this._createSubject.next();
  }

  onDelete(digitalAsset: DigitalAsset) {
    this._deleteSubject.next(digitalAsset);
  }
}

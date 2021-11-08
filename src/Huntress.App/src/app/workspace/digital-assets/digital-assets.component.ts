import { ChangeDetectionStrategy, Component, OnDestroy, ViewChild } from '@angular/core';
import { BehaviorSubject, combineLatest, Observable, of, Subject } from 'rxjs';
import { map, switchMap, takeUntil, tap } from 'rxjs/operators';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { DigitalAsset, DigitalAssetService } from '@api';
import { EntityDataSource, DigitalAssetDetailComponent } from '@shared';
import { GetDigitalAssetPage } from './get-digital-asset-page';

@Component({
  selector: 'app-digital-asset-list',
  templateUrl: './digital-assets.component.html',
  styleUrls: ['./digital-assets.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DigitalAssetsComponent implements OnDestroy {

  private readonly _destroyed$: Subject<void> = new Subject();

  @ViewChild(MatPaginator) paginator: MatPaginator;

  protected readonly _pageIndex$: BehaviorSubject<number> = new BehaviorSubject(0);
  protected readonly _pageSize$: BehaviorSubject<number> = new BehaviorSubject(5);
  protected readonly _dataSource: EntityDataSource<DigitalAsset> = new EntityDataSource(this._digitalAssetService);

  public readonly vm$: Observable<{
    dataSource: EntityDataSource<DigitalAsset>,
    columnsToDisplay: string[],
    length$: Observable<number>,
    pageNumber: number,
    pageSize: number
  }> = combineLatest([this._pageIndex$, this._pageSize$ ])
  .pipe(
    switchMap(([pageIndex,pageSize]) => combineLatest([
      of([
        'name',
        'edit'
      ]),
      of(pageIndex),
      of(pageSize)
    ])
    .pipe(
      map(([columnsToDisplay, pageNumber, pageSize]) => {
        this._dataSource.getPage({ pageIndex, pageSize });
        return {
          dataSource: this._dataSource,
          columnsToDisplay,
          length$: this._dataSource.length$,
          pageSize,
          pageNumber
        }
      })
    ))
  );

  constructor(
    private readonly _digitalAssetService: DigitalAssetService,
    private readonly _matDialog: MatDialog,
    private readonly _getDigitalAssetPage: GetDigitalAssetPage
  ) { }

  public edit(digitalAsset: DigitalAsset) {
    this._matDialog.open<DigitalAssetDetailComponent>(DigitalAssetDetailComponent, {
      data: {
        digitalAsset
      }
    }).afterClosed()
    .pipe(
      takeUntil(this._destroyed$),
      tap(x => this._dataSource.update(x))
    )
    .subscribe();
  }

  public create() {
    this._matDialog.open<DigitalAssetDetailComponent>(DigitalAssetDetailComponent)
    .afterClosed()
    .pipe(
      takeUntil(this._destroyed$),
      tap(x => this._pageIndex$.next(this._pageIndex$.value))
    ).subscribe();
  }

  public delete(digitalAsset: DigitalAsset) {
    this._digitalAssetService.remove({ digitalAsset }).pipe(
      takeUntil(this._destroyed$),
      tap(_ => this._pageIndex$.next(this._pageIndex$.value))
    ).subscribe();
  }

  ngOnDestroy() {
    this._destroyed$.next();
    this._destroyed$.complete();
  }
}

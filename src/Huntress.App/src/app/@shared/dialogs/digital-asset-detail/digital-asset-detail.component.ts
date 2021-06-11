import { Component, EventEmitter, OnDestroy, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BehaviorSubject, combineLatest, Observable, Subject } from 'rxjs';
import { map, takeUntil, tap } from 'rxjs/operators';
import { DigitalAsset } from '@api';
import { DigitalAssetService } from '@api';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-digital-asset-detail',
  templateUrl: './digital-asset-detail.component.html',
  styleUrls: ['./digital-asset-detail.component.scss'],
  host: {
    'class':'g-layout__overlay-container'
  }
})
export class DigitalAssetDetailComponent implements OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();

  public digitalAsset$: BehaviorSubject<DigitalAsset> = new BehaviorSubject(null as any);

  @Output() public saved = new EventEmitter();

  public vm$ = combineLatest([
    this.digitalAsset$
  ]).pipe(
    map(([digitalAsset]) => {
      return {
        form: new FormGroup({
          digitalAsset: new FormControl(digitalAsset, [])
        })
      }
    })
  )

  constructor(
    private readonly _dialogRef: MatDialogRef<DigitalAssetDetailComponent>,
    private readonly _digitalAssetService: DigitalAssetService) {
  }

  public save(vm: { form: FormGroup}) {
    const digitalAsset = vm.form.value.digitalAsset;
    let obs$: Observable<{ digitalAsset: DigitalAsset }>;
    if(digitalAsset.digitalAssetId) {
      obs$ = this._digitalAssetService.update({ digitalAsset })
    }
    else {
      obs$ = this._digitalAssetService.create({ digitalAsset })
    }

    obs$.pipe(
      takeUntil(this._destroyed),
      tap(x => {
        this.saved.next(x.digitalAsset);
        this._dialogRef.close(x.digitalAsset);
      })
    ).subscribe();
  }

  public cancel() {
    this._dialogRef.close();
  }

  ngOnDestroy() {
    this._destroyed.complete();
    this._destroyed.next();
  }
}

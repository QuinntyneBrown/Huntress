import { Component, EventEmitter, Input, NgModule, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { DigitalAsset } from '@api';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'or-digital-asset-detail',
  templateUrl: './digital-asset-detail.component.html',
  styleUrls: ['./digital-asset-detail.component.scss']
})
export class DigitalAssetDetailComponent {

  readonly form: FormGroup = new FormGroup({
    digitalAssetId: new FormControl(null, []),
    name: new FormControl(null, [Validators.required])
  });

  public get digitalAsset(): DigitalAsset { return this.form.value as DigitalAsset; }

  @Input("digitalAsset") public set digitalAsset(value: DigitalAsset) {
    if(!value?.digitalAssetId) {
      this.form.reset({
        name: null
      })
    } else {
      this.form.patchValue(value);
    }
  }

  @Output() save: EventEmitter<DigitalAsset> = new EventEmitter();

}

@NgModule({
  declarations: [
    DigitalAssetDetailComponent
  ],
  exports: [
    DigitalAssetDetailComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    ReactiveFormsModule
  ]
})
export class DigitalAssetDetailModule { }

import { AfterViewInit, Component, ElementRef, forwardRef, Input, NgModule, ViewChild } from '@angular/core';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { switchMap, takeUntil, tap } from 'rxjs/operators';
import { fromEvent, Subject } from 'rxjs';
import { DigitalAsset, DigitalAssetService } from '@api';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { BaseControlValueAccessor } from '@core/base-control-value-accessor';

const packageFiles = function (fileList: FileList): FormData {
  const formData = new FormData();
  for (var i = 0; i < fileList.length; i++) {
    formData.append(fileList[i].name, fileList[i]);
  }
  return formData;
}

@Component({
  selector: 'or-choose-a-file-or-drag-it-here',
  templateUrl: './choose-a-file-or-drag-it-here.component.html',
  styleUrls: ['./choose-a-file-or-drag-it-here.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => ChooseAFileOrDragItHereComponent),
      multi: true
    }
  ]
})
export class ChooseAFileOrDragItHereComponent extends BaseControlValueAccessor implements AfterViewInit  {

  private readonly _digitalAssetIds$: Subject<string[]> = new Subject();

  @ViewChild("input", { static: true }) public fileInput: ElementRef<HTMLInputElement>;

  @Input() idOnly: boolean = true;

  digitalAssetId$: Subject<string| DigitalAsset> = new Subject();

  constructor(
    private readonly _digitalAssetService: DigitalAssetService,
    private readonly _elementRef: ElementRef<HTMLElement>
  ) {
    super()
  }

  ngAfterViewInit(): void {
    fromEvent(this._elementRef.nativeElement,"dragover")
    .pipe(
      tap((x: DragEvent) => this.onDragOver(x)),
      takeUntil(this._destroyed$)
    ).subscribe();

    fromEvent(this._elementRef.nativeElement,"drop")
    .pipe(
      tap((x: DragEvent) => this.onDrop(x)),
      takeUntil(this._destroyed$)
    ).subscribe();
  }

  async onDrop(e: DragEvent): Promise<any> {
    e.stopPropagation();
    e.preventDefault();

    if (e.dataTransfer && e.dataTransfer.files) {
      const data = packageFiles(e.dataTransfer.files);
      this._upload(data);
    }
  }

  registerOnChange(fn: any): void {
    this._digitalAssetIds$
    .pipe(takeUntil(this._destroyed$))
    .subscribe(fn);
  }

  onDragOver(e: DragEvent): void {
    e.stopPropagation();
    e.preventDefault();
  }

  handleFileInput(files: FileList) {
    const data = packageFiles(files);
    this._upload(data);
  }

  private _upload(data: FormData) {
    this._digitalAssetService.upload({ data })
    .pipe(
      takeUntil(this._destroyed$)
    )
    .subscribe();
  }

  handleChooseAFileClick() { this.fileInput.nativeElement.click(); }
}

@NgModule({
  declarations: [
    ChooseAFileOrDragItHereComponent
  ],
  exports: [
    ChooseAFileOrDragItHereComponent
  ],
  imports: [
    CommonModule,
    MatIconModule
  ]
})
export class ChooseAFileOrDragItHereModule { }

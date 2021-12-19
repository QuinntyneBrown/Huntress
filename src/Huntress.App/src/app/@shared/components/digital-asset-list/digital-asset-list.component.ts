import { AfterViewInit, ChangeDetectionStrategy, Component, EventEmitter, Input, NgModule, Output, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { DigitalAsset } from '@api';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { pageSizeOptions } from '@core';

@Component({
  selector: 'or-digital-asset-list',
  templateUrl: './digital-asset-list.component.html',
  styleUrls: ['./digital-asset-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DigitalAssetListComponent implements AfterViewInit {

  private _dataSource: MatTableDataSource<DigitalAsset>;

  readonly pageSizeOptions: typeof pageSizeOptions = pageSizeOptions;

  readonly displayedColumns: string[] = ["name"];

  @ViewChild(MatPaginator, { static: true }) private _paginator: MatPaginator;

  @Input("digitalAssets") set digitalAssets(value: DigitalAsset[]) {
    this._dataSource = new MatTableDataSource(value);
  }

  get dataSource() { return this._dataSource; }

  @Output() select: EventEmitter<DigitalAsset> = new EventEmitter();

  ngAfterViewInit(): void {
    this.dataSource.paginator = this._paginator;
  }
}

@NgModule({
  declarations: [
    DigitalAssetListComponent
  ],
  exports: [
    DigitalAssetListComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatIconModule,
    MatPaginatorModule
  ]
})
export class DigitalAssetListModule { }

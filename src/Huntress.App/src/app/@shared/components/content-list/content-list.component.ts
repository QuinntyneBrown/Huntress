import { AfterViewInit, ChangeDetectionStrategy, Component, EventEmitter, Input, NgModule, Output, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { Content } from '@api';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { pageSizeOptions } from '@core';

@Component({
  selector: 'or-content-list',
  templateUrl: './content-list.component.html',
  styleUrls: ['./content-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ContentListComponent implements AfterViewInit {

  private _dataSource: MatTableDataSource<Content>;

  readonly pageSizeOptions: typeof pageSizeOptions = pageSizeOptions;

  readonly displayedColumns: string[] = ["name"];

  @ViewChild(MatPaginator, { static: true }) private _paginator: MatPaginator;

  @Input("contents") set contents(value: Content[]) {
    this._dataSource = new MatTableDataSource(value);
  }

  get dataSource() { return this._dataSource; }

  @Output() select: EventEmitter<Content> = new EventEmitter();

  ngAfterViewInit(): void {
    this.dataSource.paginator = this._paginator;
  }
}

@NgModule({
  declarations: [
    ContentListComponent
  ],
  exports: [
    ContentListComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatIconModule
  ]
})
export class ContentListModule { }

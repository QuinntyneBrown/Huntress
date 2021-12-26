import { AfterViewInit, ChangeDetectionStrategy, Component, EventEmitter, Input, NgModule, Output, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { CssVariable } from '@api';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { pageSizeOptions } from '@core';

@Component({
  selector: 'or-css-variable-list',
  templateUrl: './css-variable-list.component.html',
  styleUrls: ['./css-variable-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CssVariableListComponent implements AfterViewInit {

  private _dataSource: MatTableDataSource<CssVariable>;

  readonly pageSizeOptions: typeof pageSizeOptions = pageSizeOptions;

  readonly displayedColumns: string[] = ["name"];

  @ViewChild(MatPaginator, { static: true }) private _paginator: MatPaginator;

  @Input("cssVariables") set cssVariables(value: CssVariable[]) {
    this._dataSource = new MatTableDataSource(value);
  }

  get dataSource() { return this._dataSource; }

  @Output() select: EventEmitter<CssVariable> = new EventEmitter();

  ngAfterViewInit(): void {
    this.dataSource.paginator = this._paginator;
  }
}

@NgModule({
  declarations: [
    CssVariableListComponent
  ],
  exports: [
    CssVariableListComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatIconModule,
    MatPaginatorModule
  ]
})
export class CssVariableListModule { }

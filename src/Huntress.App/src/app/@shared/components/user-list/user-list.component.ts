import { AfterViewInit, ChangeDetectionStrategy, Component, EventEmitter, Input, NgModule, Output, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { User } from '@api';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { pageSizeOptions } from '@core';

@Component({
  selector: 'or-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  host: {
    class:'or-list-detail-container--list'
  }
})
export class UserListComponent implements AfterViewInit {

  private _dataSource: MatTableDataSource<User>;

  readonly pageSizeOptions: typeof pageSizeOptions = pageSizeOptions;

  readonly displayedColumns: string[] = ["username"];

  @ViewChild(MatPaginator, { static: true }) private _paginator: MatPaginator;

  @Input("users") set users(value: User[]) {
    this._dataSource = new MatTableDataSource(value);
  }

  get dataSource() { return this._dataSource; }

  @Output() select: EventEmitter<User> = new EventEmitter();

  ngAfterViewInit(): void {
    this.dataSource.paginator = this._paginator;
  }
}

@NgModule({
  declarations: [
    UserListComponent
  ],
  exports: [
    UserListComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatIconModule,
    MatPaginatorModule
  ]
})
export class UserListModule { }

import { ChangeDetectionStrategy, Component, EventEmitter, Input, NgModule, Output, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { User } from '@api';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { pageSizeOptions } from '@core';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'or-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UserListComponent {

  @Input() selected: User;

  private _dataSource: MatTableDataSource<User>;

  readonly pageSizeOptions: typeof pageSizeOptions = pageSizeOptions;

  readonly displayedColumns: string[] = ["name", "actions"];

  @ViewChild(MatPaginator, { static: true }) private _paginator: MatPaginator;

  @Input("users") set users(value: User[]) {
    this._dataSource = new MatTableDataSource(value);
    this.dataSource.paginator = this._paginator;
  }

  get dataSource() { return this._dataSource; }

  @Output() select: EventEmitter<User> = new EventEmitter();

  @Output() create: EventEmitter<void> = new EventEmitter();

  @Output() delete: EventEmitter<User> = new EventEmitter();

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
    MatButtonModule,
    MatPaginatorModule
  ]
})
export class UserListModule { }

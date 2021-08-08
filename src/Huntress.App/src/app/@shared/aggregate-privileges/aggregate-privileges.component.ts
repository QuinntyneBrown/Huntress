import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Privilege } from '@api';

@Component({
  selector: 'app-aggregate-privileges',
  templateUrl: './aggregate-privileges.component.html',
  styleUrls: ['./aggregate-privileges.component.scss']
})
export class AggregatePrivilegesComponent  {

  @Input("aggregatePrivileges") private _aggregatePrivileges!: any[];

  @Input("accessRights") public accessRights: number[] = [
    0,
    1,
    2,
    3,
    4
  ]

  @Output() public add: EventEmitter<any> = new EventEmitter();

  @Output() public remove: EventEmitter<any> = new EventEmitter();

  get aggregate():string { return this._aggregatePrivileges[0]; }

  get aggregatePrivileges(): Privilege[] {
    return this._aggregatePrivileges
    .slice(1)[0]
    .sort(this._compareFn);
  }

  private _compareFn = (a,b) => a.accessRight - b.accessRight;

  private _lookUp = {0: "Full", 1: "Read", 2: "Write", 3: "Create", 4: "Delete" }

  public translateAccessRight = (accessRight: number) => this._lookUp[accessRight];

  public hasAccessRight(accessRight: number): boolean {
    return this.aggregatePrivileges.filter(x => x.accessRight == accessRight).length > 0;
  }

  public handleAccessRightClick(accessRight: number) {
    const aggregatePrivilege = this.aggregatePrivileges.filter(x => x.accessRight == accessRight)[0];
    return this.hasAccessRight(accessRight)
    ? this.remove.emit(aggregatePrivilege)
    : this.add.emit({accessRight, aggregate: this.aggregate});
  }
}

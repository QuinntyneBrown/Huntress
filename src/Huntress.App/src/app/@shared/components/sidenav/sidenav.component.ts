import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent {

  @Output() public logoutClicked: EventEmitter<any> = new EventEmitter();

  public logout() {
    this.logoutClicked.emit();
  }

  @Output() public closeClick: EventEmitter<any> = new EventEmitter();

  @Output() public titleClick: EventEmitter<void> = new EventEmitter();
}

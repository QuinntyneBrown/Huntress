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
}

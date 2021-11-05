import { Component } from '@angular/core';
import { DashboardCardService } from '@api';
import { StatefulQueryService } from '@core/stateful-query.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {


  constructor(
    private readonly _dashboardCardService: DashboardCardService,
    private readonly _statefulQueryService: StatefulQueryService
  ) {

  }

}

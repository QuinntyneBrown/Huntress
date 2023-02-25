// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from '@dashboard/core';
import { createViewModel } from './home.view-model';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, DashboardComponent],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  public vm$ = createViewModel();
}


import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderDetailModule, OrderListModule, ListDetailModule } from '@shared';
import { OrdersRoutingModule } from './orders-routing.module';
import { OrdersComponent } from './orders.component';



@NgModule({
  declarations: [
    OrdersComponent
  ],
  imports: [
    CommonModule,
    OrdersRoutingModule,
    OrderListModule,
    OrderDetailModule,
    ListDetailModule
  ]
})
export class OrdersModule { }

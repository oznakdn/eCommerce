import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutModule } from './layout/layout.module';
import { ProductsModule } from './products/products.module';
import { OrdersModule } from './orders/orders.module';
import { CustomersModule } from './customers/customers.module';
import { DashboardModule } from './dashboard/dashboard.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    LayoutModule,
    OrdersModule,
    CustomersModule,
    DashboardModule,
    ProductsModule
  ],
  exports:[
    LayoutModule
  ]
})
export class AdminInterfaceModule { }

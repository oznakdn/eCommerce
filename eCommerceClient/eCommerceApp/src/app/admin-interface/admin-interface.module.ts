import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutModule } from './layout/layout.module';
import { ProductsModule } from './products/products.module';
import { OrdersModule } from './orders/orders.module';
import { CustomersModule } from './customers/customers.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { HttpClientService } from '../general/http-client.service';




@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    LayoutModule,OrdersModule,CustomersModule,DashboardModule,ProductsModule
  ],
  exports:[
    LayoutModule
  ],
  providers:[
    HttpClientService
  ]
})
export class AdminInterfaceModule { }

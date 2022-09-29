import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { OrderComponent } from './components/order/order.component';




@NgModule({
  declarations: [
    OrderComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path:'',component:OrderComponent}
    ])
  ]
})
export class OrdersModule { }

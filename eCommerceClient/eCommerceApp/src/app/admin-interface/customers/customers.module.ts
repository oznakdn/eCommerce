import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CustomerComponent } from './components/customer/customer.component';



@NgModule({
  declarations: [
   CustomerComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path:'',component:CustomerComponent}
    ])
  ]
})
export class CustomersModule { }

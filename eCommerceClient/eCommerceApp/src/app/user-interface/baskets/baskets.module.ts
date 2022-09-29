import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketComponent } from './components/basket/basket.component';
import { RouterModule } from '@angular/router';
import { LayoutModule } from '../layout/layout.module';






@NgModule({
  declarations: [
    BasketComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path:'', component:BasketComponent}
    ]),
    LayoutModule
  ]
})
export class BasketsModule { }

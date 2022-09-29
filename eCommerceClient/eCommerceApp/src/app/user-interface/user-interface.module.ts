import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketsModule } from './baskets/baskets.module';
import { HomeModule } from './home/home.module';
import { ProductsModule } from './products/products.module';
import { LayoutModule } from './layout/layout.module';





@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    BasketsModule,
    HomeModule,
    ProductsModule,
    LayoutModule
  ],
  exports:[
    LayoutModule
  ]
})
export class UserInterfaceModule { }

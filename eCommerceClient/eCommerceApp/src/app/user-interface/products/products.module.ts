import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from './components/product/product.component';
import { RouterModule } from '@angular/router';
import { LayoutModule } from '../layout/layout.module';




@NgModule({
  declarations: [
    ProductComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path:'', component:ProductComponent}
    ]),
    LayoutModule
  ]
})
export class ProductsModule { }

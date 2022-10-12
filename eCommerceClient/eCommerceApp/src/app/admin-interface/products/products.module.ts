import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from './components/product/product.component';
import { RouterModule } from '@angular/router';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { CreateProductComponent } from './components/create-product/create-product.component';
import { ListProductComponent } from './components/list-product/list-product.component';




@NgModule({
  declarations: [
    ProductComponent,
    CreateProductComponent,
    ListProductComponent

  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path:'', component:ProductComponent}
    ]),
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatSidenavModule,
    MatIconModule,
    MatButtonModule
  ],
  exports:[
    ProductComponent
  ]
})
export class ProductsModule { }

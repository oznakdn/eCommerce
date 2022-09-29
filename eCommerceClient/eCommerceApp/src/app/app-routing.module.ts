import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './admin-interface/dashboard/components/dashboard/dashboard.component';
import { LayoutComponent } from './admin-interface/layout/layout.component';
import { HomeComponent } from './user-interface/home/components/home/home.component';


const routes: Routes = [
  {path:'admin', component:LayoutComponent, children:[
      {path:'',component:DashboardComponent},
      {path:'customers',loadChildren:()=>import("./admin-interface/customers/customers.module").then(module=>module.CustomersModule)},
      {path:'orders',loadChildren:()=>import("./admin-interface/orders/orders.module").then(module=>module.OrdersModule)},
      {path:'products',loadChildren:()=>import("./admin-interface/products/products.module").then(module=>module.ProductsModule)}
  ]},
  {path:'',component:HomeComponent},
  {path:'baskets', loadChildren:()=>import("./user-interface/baskets/baskets.module").then(module=>module.BasketsModule)},
  {path:'products', loadChildren:()=>import("./user-interface/products/products.module").then(module=>module.ProductsModule)}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

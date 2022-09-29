import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { RouterModule } from '@angular/router';
import { LayoutModule } from '../layout/layout.module';
import { NgxSpinnerModule } from 'ngx-spinner';






@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path:'', component:HomeComponent}
    ]),
    LayoutModule,
    NgxSpinnerModule
  ]
})
export class HomeModule { }

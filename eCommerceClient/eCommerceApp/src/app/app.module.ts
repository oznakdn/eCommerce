import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AdminInterfaceModule } from './admin-interface/admin-interface.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserInterfaceModule } from './user-interface/user-interface.module';
import { GeneralModule } from './general/general.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    AdminInterfaceModule,UserInterfaceModule,GeneralModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

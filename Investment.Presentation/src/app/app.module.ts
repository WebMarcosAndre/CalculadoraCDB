import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; // TODO: Adicionei o formsmodule

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CalculateCdbComponent } from './components/calculate-cdb/calculate-cdb.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    CalculateCdbComponent    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule // TODO: Adicionei o formsmodule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

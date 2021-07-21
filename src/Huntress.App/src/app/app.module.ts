import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { baseUrl } from '@core';
import { HeaderModule } from '@shared/header/header.module';
import { CreateContactFormModule, FooterModule, MaterialModule } from '@shared';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    HeaderModule,
    FooterModule,
    CreateContactFormModule,
    MaterialModule
  ],
  providers: [
    { provide: baseUrl, useValue: 'https://localhost:5001/'}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

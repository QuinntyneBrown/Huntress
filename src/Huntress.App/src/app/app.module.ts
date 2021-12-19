import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ACTION_EFFECT_LOOKUP, baseUrl, BASE_URL, HeadersInterceptor, JwtInterceptor } from '@core';
import { CreateContactFormModule, FooterModule, MaterialModule } from '@shared';
import { HeaderModule } from '@shared/components/header/header.module';

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
    { provide: baseUrl, useValue: 'https://localhost:5001/'},
    { provide: BASE_URL, useValue: 'https://localhost:5001/'},
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HeadersInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

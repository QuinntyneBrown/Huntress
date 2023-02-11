import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TranslateLoader } from '@ngx-translate/core';
import { TranslateModule  } from '@ngx-translate/core';
import { TranslateHttpLoader  } from '@ngx-translate/http-loader';

export function HttpLoaderFactory(httpClient: HttpClient) {
  return new TranslateHttpLoader(httpClient);
}
// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { importProvidersFrom } from '@angular/core';
import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthGuard, BASE_URL, DEFAULT_PATH, LOGIN_PATH } from '@identity/core';



bootstrapApplication(AppComponent, {
  providers: [
    { provide: BASE_URL, useValue: '' },
    { provide: DEFAULT_PATH, useValue: '/' },
    { provide: LOGIN_PATH, useValue: '/login' },
    importProvidersFrom(
      HttpClientModule,
      TranslateModule.forRoot({
        loader: {
          provide: TranslateLoader,
          useFactory: HttpLoaderFactory,
          deps: [HttpClient]
        }
      }),
      RouterModule.forRoot([
        { path: '', loadComponent: () => import('./app/landing/landing.component').then(m => m.LandingComponent), canActivate: [AuthGuard] },
        { path: 'login', loadComponent: () => import('./app/login/login.component').then(m => m.LoginComponent) }
      ]), BrowserAnimationsModule,     
    )
  ]
}).catch((err) => console.error(err));

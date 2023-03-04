// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TranslateLoader } from '@ngx-translate/core';
import { TranslateModule  } from '@ngx-translate/core';
import { TranslateHttpLoader  } from '@ngx-translate/http-loader';
import { importProvidersFrom, inject } from '@angular/core';
import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthService, BASE_URL as IDENTITY_BASE_URL, HOME_PATH, LOGIN_PATH } from '@identity/core';
import { BASE_URL as DASHBOARD_BASE_URL } from '@dashboard/core';
import { BASE_URL as TELEMETRY_BASE_URL } from '@telemetry/core';

export function HttpLoaderFactory(httpClient: HttpClient) {
  return new TranslateHttpLoader(httpClient);
}

bootstrapApplication(AppComponent, {
  providers: [
    { provide: IDENTITY_BASE_URL, useValue: 'http://localhost:5041/' },
    { provide: DASHBOARD_BASE_URL, useValue: 'https://localhost:7007/' },
    { provide: TELEMETRY_BASE_URL, useValue: 'https://localhost:7225/' },
    { provide: HOME_PATH, useValue: '/' },
    { provide: LOGIN_PATH, useValue: '/login' },
    importProvidersFrom(
      BrowserAnimationsModule,
      HttpClientModule,
      TranslateModule.forRoot({
        loader: {
          provide: TranslateLoader,
          useFactory: HttpLoaderFactory,
          deps: [HttpClient]
        }
      }),
      RouterModule.forRoot([
        { path: '', loadComponent: () => import('./app/home/home.component').then(m => m.HomeComponent), canActivate: [() => inject(AuthService).authorize()] },
        { path: 'login', loadComponent: () => import('./app/login/login.component').then(m => m.LoginComponent) }
      ])          
    )
  ]
}).catch((err) => console.error(err));

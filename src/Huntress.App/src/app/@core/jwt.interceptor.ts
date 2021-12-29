import { Injectable } from '@angular/core';
import {
  HttpClient,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpEventType,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalStorageService } from './local-storage.service';
import { NavigationService } from './navigation.service';
import { tap } from 'rxjs/operators';
import { accessTokenKey } from './constants';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(
    private readonly _localStorageService: LocalStorageService,
    private readonly _redirectService: NavigationService
  ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      tap(
        (httpEvent: HttpEvent<any>) => httpEvent,
        error => {
          if (error instanceof HttpErrorResponse && error.status === 401) {
            this._localStorageService.put({ name: accessTokenKey, value: null });
            this._redirectService.redirectToLogin();
          }
        }
      )
    );
  }
}

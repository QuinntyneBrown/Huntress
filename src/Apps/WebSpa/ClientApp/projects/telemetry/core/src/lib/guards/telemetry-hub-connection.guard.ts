import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TelemetryHubConnectionGuard implements CanActivate {
  canActivate(
    route: ActivatedRouteSnapshot,state: RouterStateSnapshot): boolean {
    
      return false;
  }
  
}

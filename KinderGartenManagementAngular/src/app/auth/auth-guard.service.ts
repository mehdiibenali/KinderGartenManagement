import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { NbAuthService, NbAuthJWTToken } from '@nebular/auth';
import { Payload } from '../_core/_models/payload';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
user : Payload;
    constructor(
        private router: Router,
        private authService: NbAuthService
    ) {
        this.authService.onTokenChange()
            .subscribe((token: NbAuthJWTToken) => {
                if (token.isValid()) {
                    this.user = token.getPayload();
                }
            });
    }
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const currentUser = this.user;  
        if (currentUser) {
            // check if route is restricted by role
            if (route.data.roles && route.data.roles.indexOf(currentUser.role) === -1) {
                // role not authorised so redirect to home page
                this.router.navigate(['/']);
                return false;
            }
            // authorised so return true
            return true;
        }
        // not logged in so redirect to login page with the return url
        this.router.navigate(['/auth/login']);
        return false;
    }
}
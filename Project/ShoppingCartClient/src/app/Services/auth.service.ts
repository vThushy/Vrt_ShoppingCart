import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { UsersService } from './users.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService implements CanActivate {

  constructor(
    private router: Router,
    private userService: UsersService
  ) { }


  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const isLoggedIn = this.userService.isLogged();
    if (isLoggedIn) {
      return true;
    } else {
      this.router.navigate(['/login']);
      return false;
    }

  }
}

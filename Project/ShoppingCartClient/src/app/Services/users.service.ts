import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../Models/User';
import { loginAPI, userAPI } from '../Util/config';
import { Customer } from '../Models/Customer';
import { catchError } from 'rxjs/operators';
import { ExceptionHandlerService } from '../Util/exception-handler.service';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  private loggedIn = false;

  constructor(
    private httpClient: HttpClient,
    private exceptionHandlerService: ExceptionHandlerService) {
    this.loggedIn = !!localStorage.getItem('auth_token')
  }

  public registerUser(user: User, customer: Customer) {
    const header = { 'content-type': 'application/json' };
    var body = JSON.stringify(user);
    return this.httpClient.post<any>(userAPI, body, { 'headers': header })
      .pipe(catchError(this.exceptionHandlerService.handleError));
  }

  public verifyUser(user: User) {
    const header = { 'content-type': 'application/json' };
    return this.httpClient.post<any>(loginAPI, JSON.stringify(user), { 'headers': header })
      .pipe(catchError(this.exceptionHandlerService.handleError));
  }

  public setLoginStatus(status: boolean) {
    this.loggedIn = status;
  }

  updateUser() {

  }

  changePassword() {

  }

  forgetPassword() {

  }

  logout() {
    localStorage.removeItem('auth_token');
    localStorage.removeItem('auth_user');
  }

  public isLogged() {
    return this.loggedIn;
  }
}

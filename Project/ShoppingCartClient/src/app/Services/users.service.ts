import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../Models/User';
import { loginAPI, customerAPI, validUserAPI } from '../Util/config';
import { catchError } from 'rxjs/operators';
import { ExceptionHandlerService } from '../Util/exception-handler.service';
import { AddCustomerObj } from '../Models/AddCustomerObj';

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

  public registerUser(regCustomer: AddCustomerObj) {
    const header = { 'content-type': 'application/json' };
    var body = JSON.stringify(regCustomer);
    return this.httpClient.post<any>(customerAPI, body, { 'headers': header })
      .pipe(catchError(this.exceptionHandlerService.handleError));
  }

  public verifyUser(user: User) {
    const header = { 'content-type': 'application/json' };
    return this.httpClient.post<any>(loginAPI, JSON.stringify(user), { 'headers': header })
      .pipe(catchError(this.exceptionHandlerService.handleError));
  }

  public ValidateUser(userName: string) {
    return this.httpClient.get<any>(validUserAPI + "/" + userName)
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
    localStorage.removeItem('cart-products');
    localStorage.removeItem('fav-products');
    this.loggedIn = false;
  }

  public isLogged(): boolean {
    return this.loggedIn;
  }

  public getUserName(): string{
    return localStorage.getItem('auth_user');
  }

}

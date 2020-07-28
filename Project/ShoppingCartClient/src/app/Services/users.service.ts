import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../Models/User';
import { loginAPI, customerAPI } from '../Util/config';
import { catchError } from 'rxjs/operators';
import { ExceptionHandlerService } from '../Util/exception-handler.service';
import { AddCustomerObj } from '../Models/AddCustomerObj';
import * as shajs from 'sha.js';

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
    user.Password = this.EncryptPassword(user.Password);
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
    this.loggedIn = false;
  }

  public isLogged() {
    return this.loggedIn;
  }

  EncryptPassword(password: string){
   // return shajs('sha256').update({password}).digest('hex')

    return '4d7cc50ef7ead5edb9903a94eeb0fb4381b82a89ea6872bf28ae287ae751ae8c';
  }
}

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ExceptionHandlerService } from '../Util/exception-handler.service';
import { AddCustomerObj } from '../Models/AddCustomerObj';
import { customerAPI, PaymentAPI, OrderAPI } from '../Util/config';
import { catchError } from 'rxjs/operators';
import { OrderWithDetails } from '../Models/Order';
import { UsersService } from './users.service';
import { Payment } from '../Models/Payment';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  token: string;

  constructor(
    private httpClient: HttpClient,
    private exceptionHandlerService: ExceptionHandlerService,
    private userService: UsersService
  ) {
    this.token = userService.getAuthToken();
  }

  public pay(payment: Payment) {
    const header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ${this.token}' 
    })
    return this.httpClient.post<any>(PaymentAPI, JSON.stringify(payment), { headers: header })
      .pipe(catchError(this.exceptionHandlerService.handleError));
  }


}

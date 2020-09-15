import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ExceptionHandlerService } from '../Util/exception-handler.service';
import { Observable } from 'rxjs';
import { OrderCustomerAPI, OrderAPI, ActiveOrderCustomerAPI } from '../Util/config';
import { catchError } from 'rxjs/operators';
import { OrderWithDetails } from '../Models/Order';
import { UsersService } from './users.service';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  token: string;

  constructor(
    private httpClient: HttpClient,
    private exceptionHandlerService: ExceptionHandlerService,
    private userService: UsersService
  ) {
    this.token = userService.getAuthToken();
  }

  getOrdersByCustomer(userName: string): Observable<OrderWithDetails[]> {
    return this.httpClient.get<OrderWithDetails[]>(OrderCustomerAPI + '/' + userName)
      .pipe(
        catchError(this.exceptionHandlerService.handleError)
      );
  }

  getActiveOrdersByCustomer(userName: string): Observable<OrderWithDetails[]> {
    return this.httpClient.get<OrderWithDetails[]>(ActiveOrderCustomerAPI + '/' + userName)
      .pipe(
        catchError(this.exceptionHandlerService.handleError)
      );
  }

  getOrder(orderId: string): Observable<OrderWithDetails> {
    return this.httpClient.get<OrderWithDetails>(OrderAPI + '/' + orderId)
      .pipe(
        catchError(this.exceptionHandlerService.handleError)
      );
  }

  checkout(order: OrderWithDetails) {
    const header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': this.token
    })
    return this.httpClient.post<any>(OrderAPI, JSON.stringify(order), { headers: header })
      .pipe(catchError(this.exceptionHandlerService.handleError));
  }
}

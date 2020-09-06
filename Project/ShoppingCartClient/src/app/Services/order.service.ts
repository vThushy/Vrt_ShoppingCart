import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ExceptionHandlerService } from '../Util/exception-handler.service';
import { Observable } from 'rxjs';
import { OrderCustomerAPI } from '../Util/config';
import { catchError } from 'rxjs/operators';
import { OrderWithDetails } from '../Models/Order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(
    private httpClient: HttpClient,
    private exceptionHandlerService: ExceptionHandlerService
  ) { }

  getOrdersByCustomer(userName: string): Observable<OrderWithDetails[]> {
    return this.httpClient.get<OrderWithDetails[]>(OrderCustomerAPI + '/' + userName)
      .pipe(
        catchError(this.exceptionHandlerService.handleError)
      );
  }
}

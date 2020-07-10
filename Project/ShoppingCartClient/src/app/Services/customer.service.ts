import { Injectable } from '@angular/core';
import { customerAPI } from '../Util/config';
import { catchError } from 'rxjs/operators';
import { ExceptionHandlerService } from '../Util/exception-handler.service';
import { HttpClient } from '@angular/common/http';
import { AddCustomerObj } from '../Models/AddCustomerObj';

@Injectable({
  providedIn: 'root'
})

export class CustomerService {

  constructor(
    private httpClient: HttpClient,
    private exceptionHandlerService: ExceptionHandlerService) {
  }

  public registerCustomer(customer: AddCustomerObj) {
    const header = { 'content-type': 'application/json' };
    var body = JSON.stringify(customer);
    return this.httpClient.post<any>(customerAPI, body, { 'headers': header })
      .pipe(catchError(this.exceptionHandlerService.handleError));
  }

}

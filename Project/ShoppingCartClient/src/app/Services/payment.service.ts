import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ExceptionHandlerService } from '../Util/exception-handler.service';
import { AddCustomerObj } from '../Models/AddCustomerObj';
import { customerAPI, PaymentAPI } from '../Util/config';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor(
    private httpClient: HttpClient,
    private exceptionHandlerService: ExceptionHandlerService
  ) { }

}

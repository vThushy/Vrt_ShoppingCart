import { Injectable } from '@angular/core';
import { Product } from '../Models/Product';
import { HttpClient } from '@angular/common/http';
import { ExceptionHandlerService } from '../Util/exception-handler.service';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { produtAPI } from '../Util/config';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(
    private httpClient: HttpClient,
    private exceptionHandlerService: ExceptionHandlerService
  ) { }

  

  getAllProducts(): Observable<Product[]> {
   

    return this.httpClient.get<Product[]>(produtAPI)
      .pipe(
        catchError(this.exceptionHandlerService.handleError)
      );
  }
}

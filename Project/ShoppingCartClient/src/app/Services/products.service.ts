import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(
    
  ) { }


  // public get(regCustomer: AddCustomerObj) {
  //   const header = { 'content-type': 'application/json' };
  //   var body = JSON.stringify(regCustomer);
  //   return this.httpClient.post<any>(customerAPI, body, { 'headers': header })
  //     .pipe(catchError(this.exceptionHandlerService.handleError));
  // }
}

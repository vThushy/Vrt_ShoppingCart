import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExceptionHandlerService {

  constructor() { }

  handleError(error) {
    let errorMsg = '';
    if (error.error instanceof ErrorEvent) {
      errorMsg = `Error: ${error.error.message}`;
    } else {
      errorMsg = `Error code: ${error.status} \nMessage: ${error.message}`;
    }
    window.alert(errorMsg);
    console.log("Error: " + errorMsg);
    return throwError(errorMsg);
  }

}

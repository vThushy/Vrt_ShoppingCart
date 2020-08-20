import { Injectable } from '@angular/core';
import { Product } from '../Models/Product';
import { HttpClient } from '@angular/common/http';
import { ExceptionHandlerService } from '../Util/exception-handler.service';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { produtAPI, newArrivalAPI, bestSellerlAPI, productByCategory, productBySearch, cartAPI } from '../Util/config';
import { ProductList } from '../Models/ProductList';
import { ProductWithDetails } from '../Models/ProductDetails';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(
    private httpClient: HttpClient,
    private exceptionHandlerService: ExceptionHandlerService
  ) { }

  getAllProducts(page: number): Observable<ProductList> {
    return this.httpClient.get<ProductList>(produtAPI + '/page/' + page)
      .pipe(
        catchError(this.exceptionHandlerService.handleError)
      );
  }

  getProductsByCategory(category:string, page: number): Observable<ProductList> {
    return this.httpClient.get<ProductList>(productByCategory + '/' + category +'/' + page)
      .pipe(
        catchError(this.exceptionHandlerService.handleError)
      );
  }

  getProductsBySearch(search:string, page: number): Observable<ProductList> {
    return this.httpClient.get<ProductList>(productBySearch + '/'+ search + '/' + page)
      .pipe(
        catchError(this.exceptionHandlerService.handleError)
      );
  }

  getNewArrivalProducts(category: string): Observable<Product[]> {
    return this.httpClient.get<Product[]>(newArrivalAPI + '/' + category)
      .pipe(
        catchError(this.exceptionHandlerService.handleError)
      );
  }

  getBestSellingProducts(category: string): Observable<Product[]> {
    return this.httpClient.get<Product[]>(bestSellerlAPI + '/' + category)
      .pipe(
        catchError(this.exceptionHandlerService.handleError)
      );
  }

  getProduct(productId: string): Observable<ProductWithDetails>{
    return this.httpClient.get<ProductWithDetails>(produtAPI + '/' + productId)
    .pipe(
      catchError(this.exceptionHandlerService.handleError)
    );
  }

  getCartItems(productIds: string[]) {
    const header = { 'content-type': 'application/json' };
    return this.httpClient.post<any>(cartAPI, JSON.stringify(productIds), { 'headers': header })
      .pipe(catchError(this.exceptionHandlerService.handleError));
  }
}

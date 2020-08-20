import { Component, OnInit } from '@angular/core';
import { ProductsService } from 'src/app/Services/products.service';
import { ExceptionHandlerService } from 'src/app/Util/exception-handler.service';
import { Product } from 'src/app/Models/Product';
import { mainCategories } from 'src/app/Util/Categories';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
  cardTitle: string;
  mainCategories: string[][];
  urlCategory: string;
  trendingProduct: Product[];
  bestSellerProduct: Product[];

  constructor(
    private productService: ProductsService,
    private exceptionHandlerService: ExceptionHandlerService,
  ) {
    this.productService.getNewArrivalProducts('all').subscribe(
      result => {
        this.trendingProduct = result;
      },
      error => {
        this.exceptionHandlerService.handleError(error);
      });
    this.productService.getBestSellingProducts('all').subscribe(
      result => {
        this.bestSellerProduct = result;
      },
      error => {
        this.exceptionHandlerService.handleError(error);
      });
  }

  ngOnInit(): void {
    this.urlCategory = "/category";
    this.cardTitle = 'NEW COLLECTION';
    this.mainCategories = mainCategories;
  }

}

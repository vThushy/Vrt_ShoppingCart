import { Component, OnInit } from '@angular/core';
import { ProductsService } from 'src/app/Services/products.service';
import { ExceptionHandlerService } from 'src/app/Util/exception-handler.service';
import { Product } from 'src/app/Models/Product';
import { imagePath } from 'src/app/Util/paths';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
  cardTitle: string;
  mainCategories: string[][];
  urlCategory: string;
  newArrivalProduct: Product[];

  constructor(
    private productService: ProductsService,
    private exceptionHandlerService: ExceptionHandlerService,
  ) {
    this.productService.getNewArrivalProducts('all').subscribe(
      result => {
        this.newArrivalProduct = result;
      },
      error => {
        this.exceptionHandlerService.handleError(error);
      });
  }

  ngOnInit(): void {
    this.urlCategory = "/category";
    this.cardTitle = 'NEW COLLECTION';
    this.mainCategories = [
      ['SHOP WOMENs', 'women', imagePath.category_women],
      ['SHOP MENs', 'men', imagePath.category_men],
      ['SHOP KIDs', 'kid', imagePath.category_kid],
      ['SHOP LIFESTYLE', 'lifestyle', imagePath.category_lifestyle],
      ['SHOP GIFTs', 'gift', imagePath.category_gift]
    ];
  }

}

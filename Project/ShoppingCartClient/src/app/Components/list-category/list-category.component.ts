import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { imagePath } from 'src/app/Util/paths';
import { Product } from 'src/app/Models/Product';
import { ProductsService } from 'src/app/Services/products.service';
import { ExceptionHandlerService } from 'src/app/Util/exception-handler.service';
import { womenCategories, menCategories, kidCategories, lifeStyleCategories } from 'src/app/Util/Categories';

@Component({
  selector: 'app-list-category',
  templateUrl: './list-category.component.html',
  styleUrls: ['./list-category.component.css']
})

export class ListCategoryComponent implements OnInit {
  heading: string;
  categories: string[][];
  
  newArrivalProduct: Product[];
  bestSellerProduct: Product[];

  constructor(
    private route: ActivatedRoute,
    private productService: ProductsService,
    private exceptionHandlerService: ExceptionHandlerService,
  ) {
  }

  ngOnInit(): void {
    this.heading = this.route.snapshot.paramMap.get("category");
    switch (this.heading) {
      case 'women':
        this.categories = this.womenCategories;
        break;
      case 'men':
        this.categories = this.menCategories;
        break;
      case 'kid':
        this.categories = this.kidCategories;
        break;
      case 'lifestyle':
        this.categories = this.lifeStyleCategories;
        break;
    }
    this.productService.getNewArrivalProducts(this.heading).subscribe(
      result => {
        this.newArrivalProduct = result;
      },
      error => {
        this.exceptionHandlerService.handleError(error);
      });
    this.productService.getBestSellingProducts(this.heading).subscribe(
        result => {
          this.bestSellerProduct = result;
        },
        error => {
          this.exceptionHandlerService.handleError(error);
        });
  }

  urlCategory = "/product/by-category";
  womenCategories = womenCategories;
  menCategories = menCategories;
  kidCategories = kidCategories
  lifeStyleCategories = lifeStyleCategories
}

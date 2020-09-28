import { Component, OnInit, OnChanges, SimpleChanges, Input, ChangeDetectorRef } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { ProductsService } from 'src/app/Services/products.service';
import { ExceptionHandlerService } from 'src/app/Util/exception-handler.service';
import { Product } from 'src/app/Models/Product';
import { imagePath } from 'src/app/Util/paths';
import ProductFunctions from 'src/app/Util/Functions';
import { UsersService } from 'src/app/Services/users.service';

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrls: ['./list-product.component.css']
})
export class ListProductComponent implements OnInit {
  imageFolderPath = imagePath.product_image_folder;
  addToCartImagePath = imagePath.product_row_addToCart;
  removeCartImagePath = imagePath.product_row_removeFromCart;
  buyNowImagePath = imagePath.product_row_buynow;
  urlProductDetails = "/details";
  favImagePath = imagePath.product_row_favourite;
  unFavImagePath = imagePath.product_row_unFavourite;

  filterType: string;
  searchValue: string;
  noOfResults: number;
  noOfPages = 1;
  results: Product[];
  heading: string;
  pageCount: number[];

  constructor(
    private route: ActivatedRoute,
    private productService: ProductsService,
    private exceptionHandlerService: ExceptionHandlerService,
    private router: Router,
    private usersService: UsersService
  ) {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  }

  ngOnInit(): void{
    this.route.queryParams.subscribe(qp => {
      this.results = [];
      this.initFirstResults();
    })
  }

  initFirstResults() {
    this.filterType = this.route.snapshot.paramMap.get("type");
    this.searchValue = this.route.snapshot.paramMap.get("searchValue");
    this.heading = this.searchValue.replace(/[^a-zA-Z ]/g, " ");
    this.fetchProducts();
  }


  arrayOne(n: number): any[] {
    return Array(n);
  }

  fetchProducts(page: number = 1) {
    if (this.filterType == "by-category") {
      this.productService.getProductsByCategory(this.searchValue, page).subscribe(
        result => {
          this.noOfResults = result.noOfProducts;
          this.results = result.listOfProducts;
          if (this.noOfResults > 0) {
            this.noOfPages = Math.ceil(this.noOfResults / 9);
          } else {
            this.noOfPages = 1;
          }
          this.pageCount = this.arrayOne(this.noOfPages);
        },
        error => {
          this.exceptionHandlerService.handleError(error);
        });
    } else {
      this.productService.getProductsBySearch(this.searchValue, page).subscribe(
        result => {
          this.noOfResults = result.noOfProducts;
          this.results = result.listOfProducts;
          if (this.noOfResults > 0) {
            this.noOfPages = Math.ceil(this.noOfResults / 9);
          } else {
            this.noOfPages = 1;
          }
          this.pageCount = this.arrayOne(this.noOfPages);
        },
        error => {
          this.exceptionHandlerService.handleError(error);
        });
    }
  }
  
  addToFav(product: Product) {
    if (this.usersService.isLogged()) {
      let f = new ProductFunctions();
      if (f.existInFav(product)) {
        f.removeFromFav(product);
      } else {
        f.addToFav(product);
      }
    } else {
      this.router.navigateByUrl('/login');
    }
  }

  addToCart(product: Product) {
    if (this.usersService.isLogged()) {
      let f = new ProductFunctions();
      f.addToCart(product);
    } else {
      this.router.navigateByUrl('/login');
    }
  }

  cartImage(product: Product) {
    let f = new ProductFunctions();
    if (f.existInCart(product)) {
      return this.removeCartImagePath;
    }
    return this.addToCartImagePath;
  }

  favImage(product: Product) {
    let f = new ProductFunctions();
    if (f.existInFav(product)) {
      return this.favImagePath;
    }
    return this.unFavImagePath;
  }

}

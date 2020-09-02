import { Component, OnInit, Input, OnChanges, SimpleChanges, ChangeDetectorRef } from '@angular/core';
import { Product } from 'src/app/Models/Product';
import { imagePath } from 'src/app/Util/paths';
import { UsersService } from 'src/app/Services/users.service';
import { Router } from '@angular/router';
import ProductFunctions from 'src/app/Util/Functions';

@Component({
  selector: 'app-product-row',
  templateUrl: './product-row.component.html',
  styleUrls: ['./product-row.component.css']
})

export class ProductRowComponent implements OnChanges {
  imageFolderPath = imagePath.product_image_folder;
  addToCartImagePath = imagePath.product_row_addToCart;
  removeCartImagePath = imagePath.product_row_removeFromCart;
  buyNowImagePath = imagePath.product_row_buynow;
  favImagePath = imagePath.product_row_favourite;
  unFavImagePath = imagePath.product_row_unFavourite;
  urlProductDetails = "/details";

  heading: string;
  products: Product[];
  @Input() viewTitle: string;
  @Input() productList: Product[];

  constructor(
    private usersService: UsersService,
    private router: Router,
    private changeDet: ChangeDetectorRef,
  ) {
    this.heading = this.viewTitle;
    this.products = this.productList;
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.heading = this.viewTitle;
    if (changes['productList']) {
      this.products = this.productList;
    } else {
      this.router.navigateByUrl('/login');
    }
  }



  addToCart(product: Product) {
    if (this.usersService.isLogged()) {
      let f = new ProductFunctions();
      f.addToCart(product);
      this.changeDet.markForCheck();
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

  addToFav(product: Product) {
    if (this.usersService.isLogged()) {
      let f = new ProductFunctions();
      if (f.existInFav(product)) {
        f.removeFromFav(product);
      }
      else {
        f.addToFav(product);
      }
      this.changeDet.markForCheck();
    } else {
      this.router.navigateByUrl('/login');
    }
  }

  favImage(product: Product) {
    let f = new ProductFunctions();
    if (f.existInFav(product)) {
      return this.favImagePath;
    }
    return this.unFavImagePath;
  }
}

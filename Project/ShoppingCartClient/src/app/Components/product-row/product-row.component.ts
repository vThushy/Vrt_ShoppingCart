import { Component, OnInit, Input, OnChanges, SimpleChanges, ChangeDetectorRef } from '@angular/core';
import { Product } from 'src/app/Models/Product';
import { imagePath } from 'src/app/Util/paths';
import { FunctionalityService } from 'src/app/Util/functionality.service';
import { UsersService } from 'src/app/Services/users.service';
import { Router } from '@angular/router';
import Ftest from 'src/app/Util/Functions';
import ProductFunctions from 'src/app/Util/Functions';

@Component({
  selector: 'app-product-row',
  templateUrl: './product-row.component.html',
  styleUrls: ['./product-row.component.css']
})

export class ProductRowComponent implements OnChanges {
  imageFolderPath = imagePath.product_image_folder;
  addToCartImagePath = imagePath.product_row_addToCart;
  buyNowImagePath = imagePath.product_row_buynow;
  favouriteImagePath = imagePath.product_row_favourite;
  favouritedImagePath = imagePath.product_row_addToCart;
  removeCartImagePath = imagePath.product_row_favourite;
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

  addToFav(productId: number) {
    if (this.usersService.isLogged()) {
      var u = new ProductFunctions();
      u.addToFav(productId);
    } else {
      this.router.navigateByUrl('/login');
    }
  }

  addToCart(productId: number) {
    if (this.usersService.isLogged()) {
      var u = new ProductFunctions();
      u.addToCart(productId);
      this.changeDet.markForCheck();
    } else {
      this.router.navigateByUrl('/login');
    }
  }

  cartImage(productId: number) {
    var u = new ProductFunctions();
    if (u.checkInCart(productId)) {
      return this.removeCartImagePath;
    }
    return this.addToCartImagePath;
  }

  favImage(productId: number) {
    var u = new ProductFunctions();
    if (u.checkInFav(productId)) {
      return this.favouritedImagePath;
    }
    return this.favouriteImagePath;
  }
}

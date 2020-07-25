import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Product } from 'src/app/Models/Product';
import { imagePath } from 'src/app/Util/paths';

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

  heading: string;
  products: Product[];
  @Input() viewTitle: string;
  @Input() productList: Product[];

  constructor() {
    this.heading = this.viewTitle;
    this.products = this.productList;
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.heading = this.viewTitle;
    if(changes['productList']){
      this.products = this.productList;
    }
  }

  buynow(productId: number){

  }
  favourite(productId: number){

  }
  addToCart(productId: number){

  }

}

import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/Models/Product';
import ProductFunctions from 'src/app/Util/Functions';
import { imagePath } from 'src/app/Util/paths';

@Component({
  selector: 'app-favourite',
  templateUrl: './favourite.component.html',
  styleUrls: ['./favourite.component.css']
})
export class FavouriteComponent implements OnInit {
  imageFolderPath = imagePath.product_image_folder;
  favProducts: Product[] = [];

  constructor() { }

  ngOnInit(): void {
    let f = new ProductFunctions();
    this.favProducts = f.getFavProducts();
    console.log(this.favProducts);
  }

}

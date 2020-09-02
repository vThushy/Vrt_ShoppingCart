import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/Models/Product';
import ProductFunctions from 'src/app/Util/Functions';
import { imagePath } from 'src/app/Util/paths';
import { Router } from '@angular/router';

@Component({
  selector: 'app-favourite',
  templateUrl: './favourite.component.html',
  styleUrls: ['./favourite.component.css']
})
export class FavouriteComponent implements OnInit {
  imageFolderPath = imagePath.product_image_folder;
  favImagePath = imagePath.product_row_favourite;

  favProducts: Product[] = [];

  constructor(
    private router: Router
  ) { }

  ngOnInit(): void {
    let f = new ProductFunctions();
    this.favProducts = f.getFavProducts();
  }

  removeFromFav(product: Product){
    let f = new ProductFunctions();
    f.removeFromFav(product);
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate(['/favourite']);
  }); 
  }

}

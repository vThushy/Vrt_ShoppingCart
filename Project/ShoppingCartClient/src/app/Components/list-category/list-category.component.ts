import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { imagePath } from 'src/app/Util/paths';
import { Product } from 'src/app/Models/Product';
import { ProductsService } from 'src/app/Services/products.service';
import { ExceptionHandlerService } from 'src/app/Util/exception-handler.service';

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
  }

  urlCategory = "/product";
  womenCategories = [
    ['TRADITIONAL WEAR', 'women-traditional', imagePath.category_women_traditional],
    ['CASUAL WEAR', 'women-casual', imagePath.category_women_casual],
    ['FORMAL WEAR', 'women-formal', imagePath.category_women_formal],
    ['FOOT WEAR', 'women-foot', imagePath.category_women_foot],
    ['ACCESSORIES', 'women-accessories', imagePath.category_women_accessories]
  ];

  menCategories = [
    ['CASUAL WEAR', 'men-casual', 'assets/images/cat_men_casual.jpg'],
    ['FORMAL WEAR', 'men-formal', 'assets/images/cat_men_formal.jpg'],
    ['FOOT WEAR', 'mens-foot', 'assets/images/cat_men_foot.jpg'],
    ['WATCHES', 'men-watch', 'assets/images/cat_men_watch.jpg'],
    ['WALLETS', 'men-wallet', 'assets/images/cat_men_wallet.jpg'],
  ];

  kidCategories = [
    ['GIRLS', 'kid-girls', 'assets/images/cat_kid_girls.jpg'],
    ['BOYS', 'kid-boys', 'assets/images/cat_kid_boys.jpg'],
    ['INFANTS', 'kid-infants', 'assets/images/cat_kid_infants.jpg'],
    ['TOYS', 'kid-toys', 'assets/images/cat_kid_toys.jpg'],
    ['ACCESSORIES', 'kid-accessories', 'assets/images/cat_kid_accessories.jpg'],
  ];

  lifeStyleCategories = [
    ['HOME WEARS', 'kid-girls', 'assets/images/cat_kid_girls.jpg'],
    ['KITCHEN WEARS', 'kid-boys', 'assets/images/cat_kid_boys.jpg'],
    ['INFANTS', 'kid-infants', 'assets/images/cat_kid_infants.jpg'],
    ['TOYS', 'kid-toys', 'assets/images/cat_kid_toys.jpg'],
    ['ACCESSORIES', 'kid-accessories', 'assets/images/cat_kid_accessories.jpg'],
  ];
}

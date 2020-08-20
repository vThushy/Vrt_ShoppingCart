import { Component, OnInit } from '@angular/core';
import { ProductsService } from 'src/app/Services/products.service';
import { Product } from 'src/app/Models/Product';
import { ProductDetail } from 'src/app/Models/ProductDetails';
import { ExceptionHandlerService } from 'src/app/Util/exception-handler.service';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { imagePath } from 'src/app/Util/paths';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  imageFolderPath = imagePath.product_image_folder;

  productId: string;
  mainProduct: Product;
  productDetails: ProductDetail[];
  recommendProduct: Product[];
  similiarProduct: Product[];
  uniqueProducts: string[];
  previousUrl: string;

  constructor(
    private productService: ProductsService,
    private exceptionHandlerService: ExceptionHandlerService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe((event: NavigationEnd) => {
        this.previousUrl = event.url;
      });
    this.productId = this.route.snapshot.paramMap.get("productId");
    this.productService.getProduct(this.productId).subscribe(
      result => {
        this.mainProduct = result.product;
        this.productDetails = result.productDetails;
        this.uniqueProducts = [...new Set(this.productDetails.map(p => p.image))];
      },
      error => {
        this.exceptionHandlerService.handleError(error);
      });
  }

  back() {
    this.router.navigateByUrl(this.previousUrl);
  }
}

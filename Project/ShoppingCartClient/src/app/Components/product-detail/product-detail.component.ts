import { Component, OnInit } from '@angular/core';
import { ProductsService } from 'src/app/Services/products.service';
import { Product } from 'src/app/Models/Product';
import { ProductDetail } from 'src/app/Models/ProductDetails';
import { ExceptionHandlerService } from 'src/app/Util/exception-handler.service';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { imagePath } from 'src/app/Util/paths';
import { filter } from 'rxjs/operators';
import ProductFunctions from 'src/app/Util/Functions';


@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  imageFolderPath = imagePath.product_image_folder;
  previousUrl: string;
  productId: string;

  products: Product[];
  similarProducts: Product[];
  recommendProducts: Product[];
  selectedProduct :Product;
  qty: number  = 1;

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
        this.products = result;
        this.selectedProduct =this.products[0];
        this.selectedProduct.defaultImage = this.productId + '-DEF';
      },
      error => {
        this.exceptionHandlerService.handleError(error);
      });
  }

  changeProduct(selectProduct: Product){
    this.selectedProduct = selectProduct;
  }

  addToCart(productId: number){
    let u = new ProductFunctions();
    u.addToCart(productId, this.qty);
    console.log(u.getCartProducts());
  }

  increaseQty(){
    this.qty  += 1;
  }
  
  decreaseQty(){
    if( this.qty > 1){
      this.qty -+ 1;
    }
  }

  back() {
    this.router.navigateByUrl(this.previousUrl);
  }
}

import { Component, OnInit } from '@angular/core';
import { ProductsService } from 'src/app/Services/products.service';
import { Product } from 'src/app/Models/Product';
import { ExceptionHandlerService } from 'src/app/Util/exception-handler.service';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { imagePath } from 'src/app/Util/paths';
import { filter } from 'rxjs/operators';
import ProductFunctions from 'src/app/Util/Functions';
import { UsersService } from 'src/app/Services/users.service';


@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})

export class ProductDetailComponent implements OnInit {
  imageFolderPath = imagePath.product_image_folder;
  previousUrl: string;
  productId: string;

  products: Product[] = [];
  typesOfProducts: Product[] = [];
  similarProducts: Product[];
  recommendProducts: Product[];
  selectedProduct :Product;
  sizes: string[] =[];
  qty: number  = 1;

  constructor(
    private productService: ProductsService,
    private exceptionHandlerService: ExceptionHandlerService,
    private route: ActivatedRoute,
    private router: Router,
    private userService: UsersService
  ) { }

  ngOnInit(): void {
    this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe((event: NavigationEnd) => {
        this.previousUrl = event.url;
      });

    this.productId = this.route.snapshot.paramMap.get("productId");
    let uniqueIds = [];

    this.productService.getProduct(this.productId).subscribe(
      result => {
        result.forEach(element => {
          if(uniqueIds.indexOf(element.defaultImage) == -1){
            uniqueIds.push(element.defaultImage);
            this.typesOfProducts.push(element);
          }
        });
        this.products = result;
        this.changeProduct(this.products[0]);

        this.productService.getSimiliarProducts(this.products[0].categoryId).subscribe(
          result => {
            this.recommendProducts = result;
          },
          error => {
            this.exceptionHandlerService.handleError(error);
          });
      },
      error => {
        this.exceptionHandlerService.handleError(error);
      });
  }

  changeProduct(selectProduct: Product){
    this.selectedProduct = selectProduct;
    this.sizes = [];
    this.products.forEach(element => {
      if(element.defaultImage == this.selectedProduct.defaultImage){
        this.sizes.push(element.size);
      }
    });
  }

  changeProductOnSize(selectedSize: string){
    this.products.forEach(element => {
      if(element.defaultImage == this.selectedProduct.defaultImage && element.size == selectedSize){
        this.selectedProduct = element;
      }
    });
  }

  addToCart(product: Product, qty: number = 1){
    if (this.userService.isLogged()) {
      var u = new ProductFunctions();
      product.qty = qty;
      if(product.qty <= product.stock){
        u.addToCart(product);
        this.router.navigateByUrl('/cart');
      }else{
        alert("Only "+  product.stock  + " products are available!");
      }
    } else {
      this.router.navigateByUrl('/login');
    }
  }

  increaseQty(){
    this.qty +=  1;
  }
  
  decreaseQty(){
    this.qty -= 1;
  }

  back() {
    this.router.navigateByUrl(this.previousUrl);
  }
}

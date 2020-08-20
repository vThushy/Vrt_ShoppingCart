import { Component, OnInit, OnChanges } from '@angular/core';
import { DatePipe } from '@angular/common';
import ProductFunctions from 'src/app/Util/Functions';
import { ProductsService } from 'src/app/Services/products.service';
import { Product } from 'src/app/Models/Product';
import { ExceptionHandlerService } from 'src/app/Util/exception-handler.service';
import { element } from 'protractor';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
  providers: [DatePipe]
})

export class CartComponent implements OnInit {
  cartItems: string[];
  date = new Date();
  formAddNewAddress = false;
  addressId: number;
  deliveryAddress = 'Nallur, Jaffna, Sri Lanka.';
  cartProducts: Product[];
  previousUrl: string;

  constructor(
    private datePipe: DatePipe,
    private productService: ProductsService,
    private exceptionHandlerService: ExceptionHandlerService,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.router.events
    .pipe(filter(event => event instanceof NavigationEnd))
    .subscribe((event: NavigationEnd) => {
      this.previousUrl = event.url;
    });

    var f = new ProductFunctions();
    this.cartItems = f.getCartItemsAsArray();
    this.date.setDate(this.date.getDate() + 3);
    console.log(this.cartItems);

    this.productService.getCartItems(this.cartItems).subscribe(
      result => {
        this.cartProducts = result.cartItems;
      },
      error => {
        this.exceptionHandlerService.handleError(error);
      }
    );

    console.log(this.cartProducts);
  }

  getTotalItemCunt(): number{
    let count = 0;
    if( this.cartItems != null){
      count = this.cartItems.length;
    }
    return count;
  }

  addressChange(addressId: number) {
    if (addressId == 0) {
      this.formAddNewAddress = true;
    }
    this.addressId = addressId;
  }

  addressChangeSave(value) {
    // this.deliveryAddress = this.addressId;
  }

  getItemCount(productId: number): number{
    let count: number = 0;
    this.cartProducts.forEach(element => {
      if(element.id == productId){
        count++;
      }
    });
    return count;
  }

  increaseQty(productId: number){
    let increaseProduct: Product;
    for( let element of this.cartProducts){
      if(element.id == productId){
        increaseProduct = element;
        break;
      }
    };
    this.cartItems.push(increaseProduct.id.toString());
    this.cartProducts.push(increaseProduct);
  }

  decreaseQty(productId : number){
    let decreaseProduct: Product;
    for(let element of this.cartProducts){
      if(element.id == productId){
        decreaseProduct = element;
        break;
      }
    };
    let productIndex = this.cartProducts.indexOf(decreaseProduct);
    let itemIndex = this.cartItems.indexOf(decreaseProduct.id.toString());
    this.cartProducts.splice(productIndex,1)
    this.cartItems.splice(itemIndex, 1);
  }

  calculateItemTotal(price: number, qty: number): number{
    return (price * qty);
  }

  calculateNetTotal(): number{
    let sum = 0;
    if(this.cartProducts){
      this.cartProducts.forEach(element => {
        sum = sum + element.price;
      });
    }
    
    return sum;
  }

  calculateShipping(): number{
    return this.calculateNetTotal() * 0.05;
  }

  calcualteTotal(): number{
    return (this.calculateNetTotal() + this.calculateShipping());
  }

  backTo(){
    this.router.navigateByUrl(this.previousUrl);
  }








}

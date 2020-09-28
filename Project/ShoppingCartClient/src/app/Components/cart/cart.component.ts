import { Component, OnInit, OnChanges, ChangeDetectorRef } from '@angular/core';
import { DatePipe } from '@angular/common';
import ProductFunctions from 'src/app/Util/Functions';
import { ProductsService } from 'src/app/Services/products.service';
import { Product } from 'src/app/Models/Product';
import { ExceptionHandlerService } from 'src/app/Util/exception-handler.service';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';
import { imagePath } from 'src/app/Util/paths';
import { Coupon, coupons } from 'src/app/Util/Const/Coupons';
import { OrderService } from 'src/app/Services/order.service';
import { Order, OrderLines, OrderWithDetails } from 'src/app/Models/Order';
import { UsersService } from 'src/app/Services/users.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
  providers: [DatePipe]
})

export class CartComponent implements OnInit {
  imageFolderPath = imagePath.product_image_folder;
  cartProducts: Product[];
  urlProductDetails = "/details";

  date = new Date();
  formAddNewAddress = false;
  addressId: number;
  deliveryAddress = 'Nallur, Jaffna, Sri Lanka.';

  previousUrl: string;
  coupondiscount: Coupon[];
  couponCode: string;
  wrongCoupon: boolean = false;

  constructor(
    private datePipe: DatePipe,
    private productService: ProductsService,
    private exceptionHandlerService: ExceptionHandlerService,
    private userService: UsersService,
    private orderservice: OrderService,
    private router: Router,
    private changeRef: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe((event: NavigationEnd) => {
        this.previousUrl = event.url;
      });

    var f = new ProductFunctions();
    this.date.setDate(this.date.getDate() + 3);
    this.cartProducts = f.getCartProducts();
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

  getTotalItemCount(): number {
    let f = new ProductFunctions();
    return f.getCartItemsCount();
  }

  increaseQty(product: Product) {
    let f = new ProductFunctions();
    f.increaseCartItemQty(product);
    this.changeRef.detectChanges();
  }

  decreaseQty(product: Product) {
    let f = new ProductFunctions();
    f.decreaseCartItemQty(product);
    this.changeRef.reattach();
  }

  getQty(product: number): number {
    let f = new ProductFunctions();
    return f.getFromCart(product).qty;
  }

  removeItem(product: Product) {
    let f = new ProductFunctions();
    f.removeFromCart(product);
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate(['/cart']);
    });
  }

  calculateNetTotal(): number {
    let sum = 0;
    if (this.cartProducts) {
      this.cartProducts.forEach(element => {
        sum = sum + (element.price * this.getQty(element.id));
      });
    }
    return sum;
  }

  calculateShipping(): number {
    return this.calculateNetTotal() * 0.05;
  }

  calculateTotal(): number {
    return (this.calculateNetTotal() + this.calculateShipping() - this.totalDiscount());
  }

  backTo() {
    this.router.navigateByUrl(this.previousUrl);
  }

  checkout() {
    let f = new ProductFunctions();
    f.setTotal(this.calculateTotal());
    f.setDiscount(this.totalDiscount());

    this.orderservice.checkout(this.returnOrderDetails()).subscribe(
      result => {
        console.log(result);
        localStorage.setItem('tmp-order', result);

        this.router.navigate(['/payment', 'cart']);
      },
      error => {
        this.exceptionHandlerService.handleError(error);
      });
  }

  returnOrderDetails(): OrderWithDetails {
    let f = new ProductFunctions();
    let products: Product[] = f.getCartProducts();
    let orderDet : OrderWithDetails = new OrderWithDetails();

    let order = new Order();
    order.userName = this.userService.getUserName();
    order.addressId = this.addressId;
    order.discount = this.totalDiscount();

    orderDet.order = order;
    products.forEach(element => {
      let line: OrderLines = new OrderLines();
      line.productId = element.id;
      line.quantity = element.qty;
      line.unitPrice = element.price;
      orderDet.orderLines.push(line);
    });
    return orderDet;
  }

  addDiscount() {
    let f = new ProductFunctions();
    if (f.existInCoupon(this.couponCode)) {
      let c: Coupon = f.getCoupon(this.couponCode);
      this.coupondiscount.push(c);
    } else {
      this.wrongCoupon = true;
    }
  }

  removeDiscount(coupon: string) {
    let indexOfRemove: number;
    for (let i = 0; i < coupons.length; i++) {
      if (coupons[i].coupon == coupon) {
        indexOfRemove = i;
      }
    }
    coupons.splice(indexOfRemove, 1);
  }

  totalDiscount(): number {
    let totalDis: number = 0;
    if (this.coupondiscount != null) {
      this.coupondiscount.forEach(element => {
        totalDis += element.amount;
      });
    }
    return totalDis;
  }

}


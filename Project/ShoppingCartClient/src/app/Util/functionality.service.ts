import { Injectable } from '@angular/core';
import { Product } from '../Models/Product';
import { UsersService } from '../Services/users.service';
import { Router } from '@angular/router';
import Utils from './Functions';

@Injectable({
  providedIn: 'root'
})

export class FunctionalityService {

  constructor(
    private userService: UsersService,
    private router: Router
  ) { }

  public test() {
    console.log('test');
  }

  public setCartProducts(productId: number) {
    let products: string;
    if (this.getCartProducts() != null) {
      products = localStorage.getItem('cart-products');
      products += '-' + productId;
      localStorage.setItem('cart-producs', products);
    } else {
      products = productId.toString();
      localStorage.setItem('cart-producs', products);
    }
  }

  public AddToCart(productId: number) {
    if (productId != null) {
      this.setCartProducts(productId);
    }
  }

  public AddToFav(productId: number) {
    if (productId != null) {
      this.setFavProducts(productId);
    }
  }

  public getCartProducts(): string {
    return localStorage.getItem('cart-products');
  }


  public getFavProducts(): string {
    return localStorage.getItem('fav-products');
  }

  public setFavProducts(productId: number) {
    let products: string;
    if (this.getFavProducts() != null) {
      products = localStorage.getItem('fav-products');
      products += '-' + productId;
      localStorage.setItem('fav-producs', products);
    } else {
      products = productId.toString();
      localStorage.setItem('fav-producs', products);
    }
  }

  public checkInCart(productId: number): boolean {
    if (this.getCartProducts() != null) {
      return this.getCartProducts().includes(productId.toString());
    }
    return false;
  }

  public checkInFav(productId: number): boolean {
    if (this.getCartProducts() != null) {
      console.log('infave');
      return this.getFavProducts().includes(productId.toString());
    }
    console.log('notfave');
    return false;
  }

}

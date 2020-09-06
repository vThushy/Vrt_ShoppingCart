import { Product } from '../Models/Product';
import { coupons, Coupon } from './Const/Coupons';

export default class ProductFunctions {

    public removeCartProductsAttr() {
        localStorage.removeItem('cart-products');
    }

    public getCartProductsAttr(): string {
        return localStorage.getItem('cart-products');
    }

    public setCartProductsAttr(products: Product[]) {
        let attr: string;
        if (products != null) {
            this.removeCartProductsAttr();
            localStorage.setItem('cart-products', JSON.stringify(products));
        }
    }

    public existInCart(product: Product): boolean {
        if (this.getCartProducts() != null) {
            this.getCartProducts().forEach(element => {
                if (element.id == product.id) {
                    return true;
                }
            });
        }
        return false;
    }

    public getCartProducts(): Product[] {
        var attr = localStorage.getItem('cart-products');
        if (attr == "undefined") {
            return null;
        } else {
            var json = { 'retrievedProducts: ': JSON.parse(attr) };
            return json["retrievedProducts: "];
        }
    }

    public setCartProducts(product: Product) {
        let products: Product[] = [];

        if (this.getCartProducts() != null) {
            products = this.getCartProducts();
            if (this.existInCart(product)) {
                this.increaseCartItemQty(product);
            }
            else {
                products.push(product);
            }
        }
        else {
            products.push(product);
        }
        this.setCartProductsAttr(products);
    }

    public addToCart(product: Product) {
        if (product.id != null) {
            if (product.qty == null) {
                product.qty = 1;
            }
            this.setCartProducts(product);
        }
    }

    public removeFromCart(product: Product) {
        let cartItems = this.getCartProducts();
        let indexOfRemove: number;
        for (let i = 0; i < cartItems.length; i++) {
            if (cartItems[i].id == product.id) {
                indexOfRemove = i;
            }
        }
        cartItems.splice(indexOfRemove, 1);
        this.setCartProductsAttr(cartItems);
    }

    public increaseCartItemQty(product: Product) {
        let cartItems = this.getCartProducts();
        for (let i = 0; i < cartItems.length; i++) {
            if (cartItems[i].id == product.id) {
                cartItems[i].qty += 1;
            }
        }
        this.setCartProductsAttr(cartItems);
    }

    public decreaseCartItemQty(product: Product) {
        let cartItems = this.getCartProducts();
        for (let i = 0; i < cartItems.length; i++) {
            if (cartItems[i].id == product.id) {
                cartItems[i].qty -= 1;
            }
        }
        this.setCartProductsAttr(cartItems);
    }

    public getCartItemsCount(): number {
        let count = 0;
        if (this.getCartProducts()) {
            this.getCartProducts().forEach(element => {
                count += element.qty;
            });
            return count;
        }
        return null;
    }

    public getCartProductsId(): string[] {
        let ids: string[] = [];
        if (this.getCartProducts() != null) {
            this.getCartProducts().forEach(element => {
                if (element.id != null) {
                    ids.push(element.id.toString());
                }
            });
        }
        return ids;
    }

    public getFromCart(productId: number): Product {
        let cartItems = this.getCartProducts();
        let returnProduct: Product;

        cartItems.forEach(element => {
            if (element.id == productId) {
                returnProduct = element;
                returnProduct.qty = element.qty != null ? element.qty : 1;
            }
        });
        return returnProduct;
    }







    // Favourite

    public removeFavProductsAttr() {
        localStorage.removeItem('fav-products');
    }

    public getFavProductsAttr() {
        return localStorage.getItem('fav-products');
    }

    public setFavProductsAttr(products: Product[]) {
        let attr: string;
        if (products != null) {
            this.removeFavProductsAttr();
            localStorage.setItem('fav-products', JSON.stringify(products));
        }
    }

    public existInFav(product: Product): boolean {
        if (this.getFavProducts() != null) {
            this.getFavProducts().forEach(element => {
                if (element.id == product.id) {
                    return true;
                }
            });
        }
        return false;
    }

    public getFavProducts(): Product[] {
        var attr = localStorage.getItem('fav-products');

        if (attr == "undefined") {
            return null;
        } else {
            var json = { 'retrievedProducts: ': JSON.parse(attr) };
            return json["retrievedProducts: "];
        }
    }

    public addToFav(product: Product) {
        if (product.id != null) {
            let products: Product[] = [];
            products = this.getFavProducts();
            products.push(product);
            this.setFavProductsAttr(products);
        }
    }

    public removeFromFav(product: Product) {
        let cartItems = this.getFavProducts();
        let indexOfRemove: number;
        for (let i = 0; i < cartItems.length; i++) {
            if (cartItems[i].id == product.id) {
                indexOfRemove = i;
            }
        }
        cartItems.splice(indexOfRemove, 1);
        this.setFavProductsAttr(cartItems);
    }

    //Payment
    setTotal(total: number){
        localStorage.setItem('Total-Amount', total.toString());
    }

    setDiscount(discount: number){
        localStorage.setItem('Discount-amount', discount.toString());
    }

    getTotal(): number{
        return +localStorage.getItem('Total-Amount');
    }

    getDiscount(): number{
        return +localStorage.getItem('Discount-amount');
    }

    //coupon
    existInCoupon(coupon: string): boolean{
        coupons.forEach(element => {
          if(element.coupon == coupon){
            return true;
          }
          return false;
        });
        return false;
    }

    getCoupon(coupon: string): Coupon{
        coupons.forEach(element => {
            if(element.coupon == coupon){
              return element;
            }
            return null;
        });
        return null;
    }
}
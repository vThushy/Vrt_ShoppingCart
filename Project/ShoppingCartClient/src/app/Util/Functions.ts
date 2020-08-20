export default class ProductFunctions {

    public setCartProducts(productId: number) {
        let products: string;
        if (this.getCartProducts() != null) {
            products = localStorage.getItem('cart-products');
            products += '-' + productId;
            localStorage.setItem('cart-products', products);
        } else {
            products = productId.toString();
            localStorage.setItem('cart-products', products);
        }
        console.log(localStorage.getItem('cart-products'))
    }

    public addToCart(productId: number) {
        if (productId != null) {
            this.setCartProducts(productId);
        }

    }

    public addToFav(productId: number) {
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
            localStorage.setItem('fav-products', products);
        } else {
            products = productId.toString();
            localStorage.setItem('fav-products', products);
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

    public getCartItemsAsArray(): string[]{
        return this.getCartProducts().split('-');
    }

    public getCartItemsCount(): number{
        return this.getCartProducts().split('-').length;
    }

    public getFavItemsAsArray(): string[]{
        return this.getFavProducts().split('-');
    }

    public getFavItemsCount(): number{
        return this.getFavProducts().split('-').length;
    }

    public checkAlreadyExist(productId: number): boolean{
        if (this.getCartItemsAsArray().indexOf(productId.toString()) != -1 && this.getFavItemsAsArray().indexOf(productId.toString()) != -1){
            return true;
        }
        return false;
    }
}
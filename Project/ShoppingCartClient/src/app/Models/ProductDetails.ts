import { Product } from './Product'

export class ProductWithDetails{
    product: Product;
    productDetails: ProductDetail[];
}

export class ProductDetail{
    id: number;
    color: string;
    size: string;
    attributes: string;
    image: string;
}
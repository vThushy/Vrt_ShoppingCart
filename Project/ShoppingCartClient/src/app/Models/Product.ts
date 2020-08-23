export class Product{
    id: number;
    categoryId: number;
    name: string;
    description: string;
    discount: number;
    price: number;
    defaultImage: string;
    qty: number = 1;
}
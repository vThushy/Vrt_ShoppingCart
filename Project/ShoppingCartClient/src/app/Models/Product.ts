export class Product{
    id: number;
    categoryId: number;
    name: string;
    description: string;
    discount: number;
    price: number;
    defaultImage: string;
    size: string;
    qty: number
    baseProduct: number;


    constructor(id: number, categoryId: number, name: string, description: string, 
        discount: number,  price: number,  defaultImage: string,  size: string, qty: number = 1, baseProduct: number){
            this.id = id;
            this.categoryId = categoryId;
            this.name = name;
            this.description = description;
            this.discount = discount;
            this.price = price;
            this.defaultImage = defaultImage;
            this.size = size;
            this.qty = qty;
    }
}
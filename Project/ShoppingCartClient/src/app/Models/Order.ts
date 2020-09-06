export class Order {
    id: number;
    userName: string;
    addressId: number;
    discount: number;
    orderedDate: Date;
    orderStatus: string;
}

export class OrderLines{
    id: number;
    orderId: number;
    productId: number;
    unitPrice: number;
    quantity: number;
}

export class OrderWithDetails{
    order: Order;
    orderLines: OrderLines[];
}
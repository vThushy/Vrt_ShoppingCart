export class Coupon {
    coupon: string;
    amount: number;

    constructor(_coupon: string, _amount: number){
        this.coupon = _coupon;
        this.amount = _amount;
    }
}


export const coupons: Coupon[] = [
    new Coupon('NEW200', 200),
    new Coupon('APP500', 500),
    new Coupon('INV350', 350),
    new Coupon('MAX1000', 1000)
];

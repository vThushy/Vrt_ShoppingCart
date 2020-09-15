export class Payment{
    orderId: number;
    payMethod: string;
    note: string;
    amount: number;
    date: Date;

    get _payMethod(){
        if(this.payMethod == '0'){
            return 'Pay On Delivery';
        }
        else if(this.payMethod == '1'){
            return 'Shop Credit';
        }
        else if(this.payMethod == '2'){
            return 'Credit Card';
        }
    }

    // set _payMethod(value: string){
    //     if(this.payMethod == 'Pay On Delivery'){
    //         this.payMethod = '0';
    //     }
    //     else if(this.payMethod == 'Shop Credit'){
    //         this.payMethod = '1';
    //     }
    //     else if(this.payMethod == 'Credit Card'){
    //         this.payMethod = '2';
    //     }
    // }
}
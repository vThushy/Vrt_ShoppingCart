import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import ProductFunctions from 'src/app/Util/Functions';
import { Payment } from 'src/app/Models/Payment';
import { PaymentService } from 'src/app/Services/payment.service';
import { Order, OrderWithDetails } from 'src/app/Models/Order';
import { OrderService } from 'src/app/Services/order.service';
import { ExceptionHandlerService } from 'src/app/Util/exception-handler.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {
  orderId: string;
  total = 0;
  discount = 0;
  totalAfterDiscount = 0;
  paymentFrom: string;

  cardNote: string;
  storeCreditNote: string;
  payOnDeliveryNote = 'Pay on delivery.';
  order: OrderWithDetails;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private paymentService: PaymentService,
    private orderService: OrderService,
    private exceptionHandlerService: ExceptionHandlerService
  ) { }

  ngOnInit(): void {
    this.paymentFrom = this.route.snapshot.paramMap.get("from");
    this.orderId = localStorage.getItem('tmp-order');
    if (this.paymentFrom == 'cart') {
      let f = new ProductFunctions();
      this.totalAfterDiscount = f.getTotal();
      this.discount = f.getDiscount();
      this.total = this.totalAfterDiscount + this.discount;
    }else{
      this.orderService.getOrder(localStorage.getItem('tmp-order')).subscribe(
        result => {
          this.order = result;
          this.discount = this.order.order.discount;
          this.order.orderLines.forEach(element => {
            this.total += element.unitPrice;
          });
          this.totalAfterDiscount = this.total - this.discount;
        },
        error => {
          this.exceptionHandlerService.handleError(error);
        });
    }
  }

  makePay(payMethod: string, note: string) {
    let payment: Payment = new Payment();
    payment.orderId = +this.orderId;
    payment.amount = this.totalAfterDiscount;
    payment.payMethod = payMethod;
    payment.note = note;

    this.paymentService.pay(payment).subscribe(
      result => {
        if (result) {
          alert('Payement Successfull.')
          this.router.navigate(['orders']);
        } else {
          alert('Payement not made Successfully! \n Please try again...')
        }
      },
      error => {
        this.exceptionHandlerService.handleError(error);
      }
    );   
  }

}

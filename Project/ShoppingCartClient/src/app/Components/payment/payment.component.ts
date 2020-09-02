import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import ProductFunctions from 'src/app/Util/Functions';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {
  total = 0;
  discount = 0;
  totalAfterDiscount = 0;

  constructor(
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    let f = new ProductFunctions();
    this.totalAfterDiscount = f.getTotal();
    this.discount = f.getDiscount();
    this.total = this.totalAfterDiscount - this.discount;
  }

}

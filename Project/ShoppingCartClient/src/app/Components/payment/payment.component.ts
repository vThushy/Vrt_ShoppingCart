import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {
  total= 0;
  discount = 0;

  constructor(
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    let stringParam = this.route.snapshot.paramMap.get("total");
    this.total = +stringParam.substring(0, stringParam.indexOf('0'))
    this.discount = +stringParam.substring(stringParam.indexOf('0'), stringParam.length)
  }

}

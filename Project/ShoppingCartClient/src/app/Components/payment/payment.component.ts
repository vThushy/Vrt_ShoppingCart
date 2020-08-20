import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {
  @Input() total;
  finalTotal = 0;

  constructor() { }

  ngOnInit(): void {
    if(this.total != null){
      this.finalTotal = this.total;
    }
  }

}

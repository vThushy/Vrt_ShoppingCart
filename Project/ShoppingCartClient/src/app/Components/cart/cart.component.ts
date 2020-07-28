import { Component, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
  providers: [DatePipe]
})

export class CartComponent implements OnInit {
  cartItems: number;
  date = new Date();
  formAddNewAddress = false;
  addressId: number;
  deliveryAddress = 'Nallur, Jaffna, Sri Lanka.';

  constructor(private datePipe: DatePipe) { }

  ngOnInit(): void {
    this.cartItems = 2;
    this.date.setDate(this.date.getDate() + 3);

  }

  addressChange(addressId: number) {
    if (addressId == 0) {
      this.formAddNewAddress = true;
    }
    this.addressId = addressId;
  }

  addressChangeSave(value) {
    // this.deliveryAddress = this.addressId;
  }
}

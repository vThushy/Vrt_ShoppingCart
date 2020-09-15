import { Component, OnInit } from '@angular/core';
import { OrderWithDetails, OrderLines } from 'src/app/Models/Order';
import { OrderService } from 'src/app/Services/order.service';
import { UsersService } from 'src/app/Services/users.service';
import { ExceptionHandlerService } from 'src/app/Util/exception-handler.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.css']
})
export class OrderHistoryComponent implements OnInit {

  orders: OrderWithDetails[];
  activeOrders: OrderWithDetails[];
  
  selectedOrder: OrderWithDetails;

  constructor(
    private orderService: OrderService,
    private userService: UsersService,
    private exceptionHandlerService: ExceptionHandlerService,
    private router: Router
  ) { }

  ngOnInit(): void {
    let userName = this.userService.getUserName();
    if (userName != null) {
      this.orderService.getOrdersByCustomer(userName).subscribe(
        result => {
          this.orders = result;
        },
        error => {
          this.exceptionHandlerService.handleError(error);
        });
      this.orderService.getActiveOrdersByCustomer(userName).subscribe(
        result => {
          this.activeOrders = result;
          console.log(this.orders);
        },
        error => {
          this.exceptionHandlerService.handleError(error);
        });
    }
  }

  public getTotal(orderId: number): number {
    let sum: number = 0;
    this.orders.forEach(element => {
      if (element.order.id == orderId) {
        sum = this.calculateTotal(element);
      }
    });
    return sum;
  }

  calculateTotal(order: OrderWithDetails): number {
    let total: number = 0;
    order.orderLines.forEach(line => {
      total += line.unitPrice;
    });
    return total;
  }


  getOrderStatus(status: string): string {
    console.log(status);
    let returnStatus: string;
    if (status == '0') {
      returnStatus = "Active";
    }
    else if (status == '1') {
      returnStatus = "Paid";
    }
    else if (status == '2') {
      returnStatus = "Accepted";
    }
    else if (status == '3') {
      returnStatus = "Shipped";
    }
    else if (status == '4') {
      returnStatus = "Delivered";
    }
    else if (status == '5') {
      returnStatus = "Completed";
    }
    return returnStatus;
  }

  setSelectedOrder(order: OrderWithDetails){
    this.selectedOrder = order;
  }

  checkout(order: OrderWithDetails){
    localStorage.removeItem('tmp-order');
    localStorage.setItem('tmp-order', order.order.id.toString());
    this.router.navigate(['/payment','history']);
  }
}

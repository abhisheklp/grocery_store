import { Component, OnInit } from '@angular/core';
import { GroceryService } from '../service/grocery-service';

@Component({
  selector: 'app-all-orders',
  templateUrl: './all-orders.component.html',
  styleUrls: ['./all-orders.component.css']
})
export class AllOrdersComponent implements OnInit {
  constructor(private service : GroceryService) {}

  myOrders : any;

  ngOnInit(): void {
    this.service.getOrders(this.service.loginResult.userEmail).subscribe((result)=>{
      this.myOrders = result;
      //console.warn(result)
      this.myOrders.forEach((order: any) => {
        order.orderedItems = order.orderedItems.slice(0, -2);
        order.orderedQuantity = order.orderedQuantity.slice(0, -2);
        order.productId = order.productId.slice(0, -2);
        order.amountInItem = order.amountInItem.slice(0, -2);
      });
    });
  }
}

import { Component, OnInit } from '@angular/core';
import { GroceryService } from '../service/grocery-service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  constructor(private service : GroceryService) {}

  alert : boolean = false;

  cartItems : any[] = [];
  orderItems: any[] = [];
  
  itemsId : string = "";
  itemsInOrder : string = "";
  orderedQuantity : string = "";
  amountInItem : string = "";
  amountToPay : number = 0;
  
  ngOnInit(): void {
    this.service.getCartItems(this.service.loginResult.userEmail).subscribe( (result) =>{
      if(result)
      {
        this.cartItems = result;
      }
      
      for(const item of this.cartItems)
      {
        this.service.getProductById(item.productEntityId).subscribe((result)=>{
          result.productImage = result.productImage.substring(result.productImage.lastIndexOf('/') + 1);
          result.categoryEntityId = item.cartId;
          result.productQuantity = item.productQuantity;
          this.itemsId += result.productId+", ";
          this.itemsInOrder += result.productName+", ";
          this.orderedQuantity += result.productQuantity+", ";
          this.amountInItem += (result.productPrice - result.productDiscount)+", ";
          this.amountToPay += result.productQuantity*(result.productPrice - result.productDiscount);
          this.orderItems.push(result);
        })
      }
    });
  }

  placeOrder()
  {
    const placeOrder = {
      userEmail : this.service.loginResult.userEmail,
      productId : this.itemsId,
      orderedItems : this.itemsInOrder,
      orderedQuantity : this.orderedQuantity,
      amountInItem : this.amountInItem,
      orderAmount : this.amountToPay,
    }

    this.service.placeOrder(placeOrder).subscribe((result)=>{
      if(result)
      {
        this.service.deleteAllCartItems(placeOrder.userEmail).subscribe();
        this.alert = true;
        this.orderItems = [];
      }
    });
  }

  deleteItem(item : any)
  {
    this.service.deleteCartItem(item.categoryEntityId).subscribe( (result) =>{
      this.service.updateQuantity(item.productId, -item.productQuantity).subscribe();
      setTimeout(() => {
        location.reload();
      }, 20);
    })
  }

  closeAlert()
  {
    this.alert = true;
  }
}

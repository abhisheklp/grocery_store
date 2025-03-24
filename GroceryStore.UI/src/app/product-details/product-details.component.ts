import { Component, OnInit } from '@angular/core';
import { GroceryService } from '../service/grocery-service';
import { ActivatedRoute } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  constructor(private service : GroceryService, private router: ActivatedRoute) {}
  
  selectedOption : string | undefined = "";
  alert : boolean = false;
  reviewAlert : boolean = false;
  quantity : boolean = true;
  product : any;
  reviews : any;

  options = [
    { value: "", text: "Select Quantity" }
  ];

  isUser : string | undefined;
  isAdmin : boolean = false;

  addNewReview = new FormGroup({
    reviewText : new FormControl('',[Validators.required, Validators.maxLength(200)]),
    reviewRating: new FormControl('',[Validators.required, Validators.min(0), Validators.max(5)])
  })

  ngOnInit(): void {
    this.service.getProductById(this.router.snapshot.params['id']).subscribe((result)=> {
      result.productImage = result.productImage.substring(result.productImage.lastIndexOf('/') + 1);
      this.product = result;
      if(result.productQuantity == 0)
      {
        this.quantity = false;
      }
      else
      {
        if(result.productQuantity > 3 )
        {
          for(let i = 1; i <= 3; i++)
          {
            this.options.push({value : `${i}`, text: `${i}`});
          }
        }
        else
        {
          for(let i = 1; i <= result.productQuantity; i++)
          {
            this.options.push({value : `${i}`, text: `${i}`});
          }
        }
      }
      //console.warn(result);
    });
    this.service.getReviewByProductId(this.router.snapshot.params['id']).subscribe((result) =>{
      //console.warn(result);
      this.reviews = result;
    })
    this.isUser = this.service.loginResult.userEmail;
    this.isAdmin = this.service.loginResult.userIsAdmin;
  }

  addToCart()
  {
    const cartItem = {
      productEntityId : Number(this.router.snapshot.params['id']),
      productQuantity : Number(this.selectedOption),
      userName : this.service.loginResult.userEmail
    }

    this.service.addToCart(cartItem).subscribe( (result) => {
      this.alert = true;
      this.service.updateQuantity(cartItem.productEntityId, cartItem.productQuantity).subscribe();
    })
  }

  addReview()
  {
    if(this.addNewReview.valid)
    {
      const newReview = {
        productEntityId : Number(this.router.snapshot.params['id']),
        reviewText : this.addNewReview.value.reviewText,
        reviewRating : this.addNewReview.value.reviewRating,
        userEmail : this.isUser
      }
      this.service.addReview(newReview).subscribe((result) => {
        //console.warn(result);
        this.reviewAlert = true;
        setTimeout(() => {
          location.reload();
        }, 20);
      });
    }
  }

  closeAlert()
  {
    this.alert=false;
    this.reviewAlert = false;
  }
}

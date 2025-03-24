import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { ProductComponent } from './product/product.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { CartComponent } from './cart/cart.component';

const routes: Routes = [
  { path : '', component : HomeComponent },
  { path : 'login', component : LoginComponent},
  { path : 'signup', component : SignupComponent},
  { path : 'product', component : ProductComponent},
  { path : 'product/productDetails/:id', component : ProductDetailsComponent},
  { path : 'cart', component : CartComponent},
  // { path : 'myOrders', component : OrdersComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

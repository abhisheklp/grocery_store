import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs/internal/Observable';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GroceryService {

  url = "http://localhost:5112";

  // To store the userName, userEmail, isAdmin details
  public loginResult : any;

  constructor(private http : HttpClient) { }

  // Logout Functionality
  public showLogoutButton: boolean = false;

  // Account service to handle the Login and SignUp API
  signUp(data : any) : Observable<any>
  {
    return this.http.post<any>(`${this.url}/authenticate/signup`, data);
  }

  login(data : any) : Observable<any>
  {
    return this.http.post<any>(`${this.url}/authenticate/login`, data)
    .pipe(
      tap( response => {
        this.loginResult = response;
      })
    )
  }
  
  logout() : Observable<any>
  {
    return this.http.get<any>(`${this.url}/authenticate/logout`);
  }

  // Category service to get the all category and add the category
  getCategories() : Observable<any>
  {
    return this.http.get<any>(`${this.url}/category`);
  }

  addCategory(data : any) : Observable<any>
  {
    return this.http.get<any>(`${this.url}/category`, data);
  }

  // Product service to full-fill all the crud functionalities
  addProduct(data : any) : Observable<any>
  {
    return this.http.post<any>(`${this.url}/product`, data);
  }

  updateQuantity(id : number, decQuantity : number) : Observable<any>
  {
    return this.http.patch<any>(`${this.url}/product/${id}/${decQuantity}`, {});
  }

  updateProduct(data : any) : Observable<any>
  {
    return this.http.put<any>(`${this.url}/product/`, data);
  }

  getProductById(id : number) : Observable<any>
  {
    return this.http.get<any>(`${this.url}/product/${id}`);
  }

  getAllProducts() : Observable<any>
  {
    return this.http.get<any>(`${this.url}/product`);
  }

  getProductsByCategoryId(categoryId : number) : Observable<any>
  {
    return this.http.get<any>(`${this.url}/product/category/${categoryId}`);
  }

  searchProduct(query : string) : Observable<any>
  {
    return this.http.get<any>(`${this.url}/product/search/?query=${query}`);
  }

  deleteProductById(id : number) : Observable<any>
  {
    return this.http.delete<any>(`${this.url}/product"/${id}`);
  }

  // Cart service to get the get the all functinalities

  addToCart(data : any) : Observable<any>
  {
    return this.http.post<any>(`${this.url}/cart`, data);
  }

  getCartItems(userEmail : string) : Observable<any>
  {
    return this.http.get<any>(`${this.url}/cart/${userEmail}`);
  }

  updateCartItem(id : number, quantity : number) : Observable<any>
  {
    return this.http.patch<any>(`${this.url}/cart/${id}/${quantity}`, [id, quantity]);
  }

  deleteCartItem(id : number) : Observable<any>
  {
    return this.http.delete<any>(`${this.url}/cart/item/${id}`);
  }

  deleteAllCartItems(userName : string) : Observable<any>
  {
    return this.http.delete<any>(`${this.url}/cart/user/${userName}`);
  }

  // Orders Service to handle the order functionalities
  getOrders(userEmail : string) : Observable<any>
  {
    return this.http.get<any>(`${this.url}/myOrder/${userEmail}`);
  }

  placeOrder(data : any) : Observable<any>
  {
    return this.http.post<any>(`${this.url}/myOrder`, data);
  }

  // Review Service to handle the review functionalities like add and get review
  addReview(data : any) : Observable<any>
  {
    return this.http.post<any>(`${this.url}/review`,data);
  }

  getReviewByProductId(productId : number) : Observable<any>
  {
    return this.http.get<any>(`${this.url}/review/${productId}`);
  }
}

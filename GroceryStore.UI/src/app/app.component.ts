import { Component, OnInit } from '@angular/core';
import { GroceryService } from './service/grocery-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit{

  constructor(private service : GroceryService) {}
  title = 'Grocery Store';

  ngOnInit(): void {
    const userDetails = localStorage.getItem('userDetails');
    if(userDetails)
    {
      this.service.loginResult=JSON.parse(userDetails);
    }
  }
}


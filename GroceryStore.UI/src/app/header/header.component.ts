import { Component, OnInit } from '@angular/core';
import { GroceryService } from '../service/grocery-service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit{
  constructor(public service : GroceryService) {}

  isUser : boolean | undefined;
  isAdmin : boolean | undefined;

  ngOnInit(): void {
      this.isUser = this.service.loginResult.userEmail;
      this.isAdmin = this.service.loginResult.userIsAdmin;
  }

  logOut()
  {
    this.service.logout().subscribe( (result) =>{
      this.service.loginResult = null;
      localStorage.removeItem('userDetails');
      setTimeout(() => {
        location.reload();
      }, 20);
    })
  }
}

import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { GroceryService } from '../service/grocery-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private loginService : GroceryService, private router : Router){}

  isUnAuth : boolean = false;

  loginUser = new FormGroup({
    email : new FormControl('',[Validators.required, Validators.email]),
    password: new FormControl('',Validators.required)
  })

  login()
  {
    if(this.loginUser.valid)
    {
      const loginData = {
        email : this.loginUser.value.email,
        password : this.loginUser.value.password
      };

      this.loginService.login(loginData).subscribe( (result) =>
      {
        if(result)
        {
          localStorage.setItem('userDetails', JSON.stringify(result));
          this.loginUser.reset({});
          if(this.loginService.loginResult.userIsAdmin)
          {
            this.router.navigate(["/product"]);
            setTimeout(() => {
              location.reload();
            }, 20);
          }
          else
          {
            this.router.navigate([""]);
            setTimeout(() => {
              location.reload();
            }, 20);
          }
        }
      },
      (error) => {
        this.isUnAuth = true;
      })
    }
  }

}

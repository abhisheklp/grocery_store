import { Component } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { GroceryService } from '../service/grocery-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {

  constructor(private signupService : GroceryService, private router : Router){}
  alert : boolean | undefined;

  signupUser = new FormGroup({
    fullName : new FormControl('', [Validators.required, Validators.maxLength(50)]),
    email : new FormControl('', [Validators.required, Validators.email]),
    phoneNo : new FormControl('', Validators.required),
    password: new FormControl('', [Validators.required, Validators.minLength(8), this.passwordValidator()]),
    confirmPassword : new FormControl('', Validators.required)},
    { validators: this.passwordMatchValidator }
  );

  passwordValidator(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
      const passwordRegex = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/;
      const valid = passwordRegex.test(control.value);
      return valid ? null : { invalidPassword: true };
    };
  }

  passwordMatchValidator(control: AbstractControl): { [key: string]: any } | null {
    const password = control.get('password');
    const confirmPassword = control.get('confirmPassword');
    if (password?.value !== confirmPassword?.value) {
      return { passwordMismatch: true };
    }
    return null;
  }

  signup()
  {
    if(this.signupUser.valid)
    {
      const signUpData = {
        fullName : this.signupUser.value.fullName,
        email : this.signupUser.value.email,
        phoneNo : this.signupUser.value.phoneNo,
        password : this.signupUser.value.password,
        confirmPassword : this.signupUser.value.confirmPassword,
        isAdmin : false
      };

      this.signupService.signUp(signUpData).subscribe( (result) =>
      {
        if(result)
        {
          this.alert = true;
          this.signupUser.reset({});
          setTimeout(() => {
            this.router.navigate(["login"]);
          }, 3000);
        }
      })
    }
  }

  closeAlert()
  {
    this.alert = false;
  }

}

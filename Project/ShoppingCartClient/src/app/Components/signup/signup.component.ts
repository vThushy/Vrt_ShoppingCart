import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UsersService } from 'src/app/Services/users.service';
import { CustomerService } from 'src/app/Services/customer.service';
import { ExceptionHandlerService } from 'src/app/Util/exception-handler.service';
import { AddCustomerObj } from 'src/app/Models/AddCustomerObj';
import { Router } from '@angular/router';
import { imagePath } from 'src/app/Util/paths';
import { country_list } from 'src/app/Util/Const/Countries';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})

export class SignupComponent implements OnInit {
  logoImagePath = imagePath.home_logo;
  countries = country_list;
  signUpForm: FormGroup;
  // regExEmail = Validators.pattern('^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$');
  regExPhone = "^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$";
  customer = new AddCustomerObj();
  isSubmitted = false;
  acceptedUserName: string = "";
  passwordNotMatch= false;

  constructor(
    private formBuilder: FormBuilder,
    private customerService: CustomerService,
    private exceptionHandlerService: ExceptionHandlerService,
    private userService: UsersService,
    private router: Router) {
  }

  ngOnInit() {
    this.createForm();
  }

  submit() {
    this.isSubmitted = true;
    if(this.registrationDetails.password.value != this.registrationDetails.repassword.value){
      this.passwordNotMatch = true;
    }
    this.customer.User.UserName = this.registrationDetails.userName.value;
    this.customer.User.Password = this.registrationDetails.password.value;
    this.customer.User.UserRole = 1;

    this.customer.Customer.UserName = this.registrationDetails.userName.value;
    this.customer.Customer.FirstName = this.registrationDetails.firstName.value;
    this.customer.Customer.LastName = this.registrationDetails.lastName.value;
    this.customer.Customer.Gender = +this.registrationDetails.gender.value;
    this.customer.Customer.DateOfBirth = this.registrationDetails.dob.value;
    this.customer.Customer.Phone = this.registrationDetails.phone.value;
    this.customer.Customer.Email = this.registrationDetails.email.value;

    this.customer.Address.UserName =  this.registrationDetails.userName.value;
    this.customer.Address.AddressType = "Main";
    this.customer.Address.AddressLine = this.registrationDetails.address.value;
    this.customer.Address.ZipCode = this.registrationDetails.zipCode.value;
    this.customer.Address.City = this.registrationDetails.city.value;
    this.customer.Address.State = this.registrationDetails.state.value;
    this.customer.Address.Country = this.registrationDetails.country.value;

    if (this.signUpForm.invalid) {
      return;
    } else {
      console.log(this.customer);
      this.customerService.registerCustomer(this.customer).subscribe(
        result => {
          localStorage.setItem('auth_token', result.token);
          localStorage.setItem('auth_user', this.customer.User.UserName);
          this.userService.setLoginStatus(true);
          this.router.navigate(['']);
        },
        error => {
          this.exceptionHandlerService.handleError(error);
        }
      );
    }
  }

  createForm() {
    this.signUpForm = this.formBuilder.group({
      userName: ['', [Validators.required, Validators.minLength(5)]],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: [''],
      address: ['', Validators.required],
      zipCode: [''],
      city: ['', Validators.required],
      state: [''],
      country: [''],
      gender: [''],
      dob: [''],
      phone: ['', Validators.pattern(this.regExPhone)],
      password: ['', [Validators.required, Validators.minLength(5)]],
      repassword: ['', [Validators.required, Validators.minLength(5)]],
    });
  }

  get registrationDetails() { return this.signUpForm.controls }

  AvailablityUserName(event) {
    let userName = event.target.value;

    if (userName.length > 0) {
      setTimeout(() => {
        this.userService.ValidateUser(userName).subscribe(
          result => {
            if (result && userName.length > 4) {
              this.acceptedUserName = "Accept";
            } else {
              this.acceptedUserName = "Not Valid!";
            }
          },
          error => {
            this.exceptionHandlerService.handleError(error);
          }
        );
      }, 5000);
    }
    this.acceptedUserName = "Not Valid!";
  }

}

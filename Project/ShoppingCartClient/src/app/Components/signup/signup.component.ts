import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UsersService } from 'src/app/Services/users.service';
import { Customer } from 'src/app/Models/Customer';
import { User } from 'src/app/Models/User';
import { CustomerService } from 'src/app/Services/customer.service';
import { ExceptionHandlerService } from 'src/app/Util/exception-handler.service';
import { AddCustomerObj } from 'src/app/Models/AddCustomerObj';
import { Router } from '@angular/router';
import { imagePath } from 'src/app/Util/paths';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})

export class SignupComponent implements OnInit {
  logoImagePath = imagePath.home_logo;
  countries = [];
  signUpForm: FormGroup;
  regExEmail = "/^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i";
  customer = new AddCustomerObj();

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
    this.customer.User.UserName = this.registrationDetails.userName.value;
    this.customer.User.Password = this.registrationDetails.password.value;
    this.customer.User.UserRole = 1;
    this.customer.Customer.UserName = this.registrationDetails.firstName.value;
    this.customer.Customer.FirstName = this.registrationDetails.firstName.value;
    this.customer.Customer.LastName = this.registrationDetails.lastName.value;
    this.customer.Customer.Gender = this.registrationDetails.gender.value;
    this.customer.Customer.DateOfBirth = this.registrationDetails.dateOfBirth.value;
    this.customer.Customer.Phone = this.registrationDetails.phone.value;
    this.customer.Customer.Email = this.registrationDetails.email.value;

    this.customer.Address.AddressType = "Main Address";
    this.customer.Address.AddressLine = this.registrationDetails.address.value;
    this.customer.Address.ZipCode = this.registrationDetails.zipCode.value;
    this.customer.Address.City = this.registrationDetails.city.value;
    this.customer.Address.State = this.registrationDetails.state.value;
    this.customer.Address.Country = this.registrationDetails.country.value;

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

  createForm() {
    this.signUpForm = this.formBuilder.group({
      userName: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.pattern(this.regExEmail)],
      address: [''],
      zipCode: [''],
      city: [''],
      state: [''],
      country: [''],
      gender: [''],
      dob: [''],
      phone: [''],
      password: ['', Validators.required, Validators.minLength(5)],
      repassword: ['', Validators.required, Validators.minLength(5)],
    });
  }

  get registrationDetails() { return this.signUpForm.controls }

}

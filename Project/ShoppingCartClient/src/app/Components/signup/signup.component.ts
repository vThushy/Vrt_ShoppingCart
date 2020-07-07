import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UsersService } from 'src/app/Services/users.service';
import { Customer } from 'src/app/Models/Customer';
import { User } from 'src/app/Models/User';
import { CustomerService } from 'src/app/Services/customer.service';
import { ExceptionHandlerService } from 'src/app/Util/exception-handler.service';
import { AddCustomerObj } from 'src/app/Models/AddCustomerObj';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})

export class SignupComponent implements OnInit {
  countries = [];
  signUpForm: FormGroup;
  regExEmail = "/^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i";
  customer = new AddCustomerObj();
 
  constructor(
    private formBuilder: FormBuilder, 
    private customerService: CustomerService,
    private exceptionHandlerService: ExceptionHandlerService) {
  }

  ngOnInit() {
    this.createForm();
  }

  submit() {
    this.customer.User.UserName = this.registrationDetails.userName.value;
    this.customer.User.Password = this.registrationDetails.password.value;
    this.customer.Customer.UserName = this.registrationDetails.firstName.value;
    this.customer.Customer.FirstName = this.registrationDetails.firstName.value;
    this.customer.Customer.LastName = this.registrationDetails.lastName.value;
    this.customer.Customer.Address.AddressType = this.registrationDetails.addressType.value;
    this.customer.Customer.Address.AddressLine = this.registrationDetails.address.value;
    this.customer.Customer.Address.ZipCode = this.registrationDetails.zipCode.value;
    this.customer.Address.City = this.registrationDetails.city.value;
    this.customer.Address.State = this.registrationDetails.state.value;
    this.customer.Address.Country = this.registrationDetails.country.value;
    this.customer.Gender = this.registrationDetails.gender.value;
    this.customer.DateOfBirth = this.registrationDetails.dateOfBirth.value;
    this.customer.Phone = this.registrationDetails.phone.value;
    this.customer.Email = this.registrationDetails.email.value;

    this.customerService.registerCustomer(this.customer).subscribe(
      result => {
        localStorage.setItem('auth_token', result.token);
        localStorage.setItem('auth_user', this.user.UserName);
       // this.userService.setLoginStatus(true);
       // this.router.navigate(['']);
      },
      error => {
        this.exceptionHandlerService.handleError(error);
      }
    );

   // this.userService.registerUser(this.user)
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
      phone:[''],
      password: ['', Validators.required, Validators.minLength(5)],
      repassword:['', Validators.required, Validators.minLength(5)],
    });
  }

  get registrationDetails() { return this.signUpForm.controls}

}

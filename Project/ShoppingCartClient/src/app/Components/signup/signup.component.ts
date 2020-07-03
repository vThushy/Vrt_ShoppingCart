import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UsersService } from 'src/app/Services/users.service';
import { Customer } from 'src/app/Models/Customer';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})

export class SignupComponent implements OnInit {
  countries = [];
  signUpForm: FormGroup;
  regExEmail = "/^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i";
  customer = new Customer();
 
  constructor(
    private formBuilder: FormBuilder, 
    private userService: UsersService) {
  }

  ngOnInit() {
    this.createForm();
  }

  submit() {
    this.customer.UserName = this.registrationDetails.userName.value;
    this.customer.Password = this.registrationDetails.password.value;
    this.customer.FirstName = this.registrationDetails.firstName.value;
    this.customer.LastName = this.registrationDetails.lastName.value;
    this.customer.Address.AddressType = this.registrationDetails.addressType.value;
    this.customer.Address.AddressLine = this.registrationDetails.address.value;
    this.customer.Address.ZipCode = this.registrationDetails.zipCode.value;
    this.customer.Address.City = this.registrationDetails.city.value;
    this.customer.Address.State = this.registrationDetails.state.value;
    this.customer.Address.Country = this.registrationDetails.country.value;
    this.customer.Gender = this.registrationDetails.gender.value;
    this.customer.DateOfBirth = this.registrationDetails.dateOfBirth.value;
    this.customer.Phone = this.registrationDetails.phone.value;
    this.customer.Email = this.registrationDetails.email.value;
    this.userService.verifyUser(this.customer);
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
      repassword:[''],
    });
  }

  get registrationDetails() { return this.signUpForm.controls}

}

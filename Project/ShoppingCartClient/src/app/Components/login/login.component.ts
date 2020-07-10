import { Component, OnInit } from '@angular/core';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { User } from 'src/app/Models/User';
import { UsersService } from 'src/app/Services/users.service';
import { Router } from '@angular/router';
import { ExceptionHandlerService } from 'src/app/Util/exception-handler.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  user = new User();
  loading = false;

  constructor(
    private formBuilder: FormBuilder,
    private userService: UsersService,
    private exceptionHandlerService: ExceptionHandlerService,
    private router: Router) {
  }

  ngOnInit() {
    this.createForm();
  }

  submit() {
    this.loading = true;
    this.user.UserName = this.loginDetails.userName.value;
    this.user.Password = this.loginDetails.password.value;

    this.userService.verifyUser(this.user).subscribe(
      result => {
        localStorage.setItem('auth_token', result.token);
        localStorage.setItem('auth_user', this.user.UserName);
        this.userService.setLoginStatus(true);
        this.loading = false;
        this.router.navigate(['']);
      },
      error => {
        this.loading = false;
        this.exceptionHandlerService.handleError(error);
      }
    );
  }

  createForm() {
    this.loginForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required, Validators.minLength(5)]
    });
  }

  get loginDetails() { return this.loginForm.controls }

}

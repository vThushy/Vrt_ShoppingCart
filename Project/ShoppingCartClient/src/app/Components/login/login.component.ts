import { Component, OnInit } from '@angular/core';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { User } from 'src/app/Models/User';
import { UsersService } from 'src/app/Services/users.service';
import { Router, NavigationEnd } from '@angular/router';
import { ExceptionHandlerService } from 'src/app/Util/exception-handler.service';
import { imagePath } from 'src/app/Util/paths';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  error: string;
  errorMsg: string;
  logoImagePath = imagePath.home_logo;
  loginForm: FormGroup;
  user = new User();
  loading = false;
  wrongCredentials = false;
  isSubmitted = false;
  previousUrl: string;

  constructor(
    private formBuilder: FormBuilder,
    private userService: UsersService,
    private exceptionHandlerService: ExceptionHandlerService,
    private router: Router
  ) {
  }

  ngOnInit() {
    this.createForm();
  }

  submit() {
    this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe((event: NavigationEnd) => {
        this.previousUrl = event.url;
      });

    this.isSubmitted = true;
    this.errorMsg = '';
    this.user.UserName = this.loginDetails.userName.value;
    this.user.Password = this.loginDetails.password.value;

    if (this.loginForm.invalid) {
      return;
    } else {
      this.loading = true;
      this.userService.verifyUser(this.user).subscribe(
        result => {
          console.log(result);
          if (result.token != "") {
            localStorage.setItem('auth_token', result.token);
            localStorage.setItem('auth_user', this.user.UserName);
            this.userService.setLoginStatus(true);
            this.loading = false;
            this.router.navigateByUrl(this.previousUrl);
          } else {
            this.loading = false;
            this.errorMsg = "Wrong username or password!"
          }
        },
        error => {
          this.loading = false;
          this.exceptionHandlerService.handleError(error);
        }
      );
    }
  }

  createForm() {
    this.loginForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  get loginDetails() {
    return this.loginForm.controls;
  }

}


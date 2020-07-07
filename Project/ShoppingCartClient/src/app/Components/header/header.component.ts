import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import { UsersService } from 'src/app/Services/users.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  accountStatus: string = "My Account";
  loggedIn = false;
  cartTotal = 0;

  constructor(
    private router: Router,
    private usersService: UsersService,
    private changeRef: ChangeDetectorRef) { }

  ngOnInit(): void {
    if (this.usersService.isLogged()){
      this.loggedIn = true;
      this.accountStatus = localStorage.getItem('auth_user')
    }
  }

  logout(){
    this.usersService.logout();
    this.loggedIn = false;
    this.accountStatus = "My Account";
  }
}

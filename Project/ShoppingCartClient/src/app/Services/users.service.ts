import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../Models/User';
import { loginAPI } from '../Util/config';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private httpClient: HttpClient) { }

  registerUser(){

  }

  public verifyUser(user: User) {
    console.log(user);
    var token: string;
    const head = {'content-type': 'application/json'};
    var  d= '{"UserName" : "Thushy", "Password" : "Thushy"}';
    var a = JSON.stringify(user);
    console.log(a);
    this.httpClient.post<any>('https://localhost:5001/Authentication', a, {'headers':  head}).subscribe(data => {
      token = data.token;
      console.log(data);
      return data;
    });
   
  //  var token=   this.httpClient.post<any>('http://localhost:5000/Authentication', user).toPromise();
  //  console.log(token);
  //  return token;
  }

  updateUser(){

  }

  changePassword(){

  }

  forgetPassword(){

  }
}

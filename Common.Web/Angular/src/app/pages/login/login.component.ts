import { Component, OnInit } from '@angular/core';
import {Authenticate, UsersService, FileResponse, AuthenticatedUser} from '../../services/webserviceproxy'
import { Observable, of } from 'rxjs';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [UsersService]
})
export class LoginComponent implements OnInit {

  authenticate: Authenticate = new Authenticate();

  constructor(private usersService: UsersService) { }

  ngOnInit(): void {
  }

  login(){

    this.usersService.authenticate(this.authenticate).subscribe(response => {
      sessionStorage.setItem('token', response.token);
      sessionStorage.setItem('userId', response.userId);
    }, (error) => {
      if(error.status === 401){
        alert("Username or Password is incorrect");
      }
    });
    
  }

}

import { Component, OnInit } from '@angular/core';
import {Authenticate, UsersService, FileResponse} from '../../services/webserviceproxy'
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
      console.log(response);
      sessionStorage.setItem('token', response.token);
    }, (error) => {
      if(error.status === 401){
        alert("Username or Password is incorrect");
      }
    });
    
  }

}

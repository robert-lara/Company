import { Component, OnInit } from '@angular/core';
import {Authenticate, UsersClient} from '../../services/webserviceproxy'


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [UsersClient]
})
export class LoginComponent implements OnInit {

  authenticate: Authenticate = new Authenticate();

  constructor(private userClient: UsersClient) { }

  ngOnInit(): void {
  }

  login(){
    
    console.log(this.authenticate)
    this.userClient.authenticate(this.authenticate).subscribe(result => {
      console.log(result);
    }, (error) => {
      console.log(error);
    });
    
  }

}

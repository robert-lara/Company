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
      let reader = new FileReader();
      reader.onload = function() {
        let message = JSON.parse(this.result.toString());
        console.log(message);
        return message;
      };
      reader.readAsText(response.data)
    }, (error) => {
      let errorMessage = JSON.parse(error.response);
      if(error.status === 401){
        alert("Username or Password is incorrect");
      }
    });
    
  }

}

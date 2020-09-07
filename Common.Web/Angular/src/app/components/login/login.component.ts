import { Component, OnInit } from '@angular/core';
import {Authenticate, UsersClient} from '../../services/webserviceproxy'
import { ResponseAdapter } from 'src/app/helpers/responseadapter';


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
    
    this.userClient.authenticate(this.authenticate).subscribe(result => {
      let reader = new FileReader();
      reader.onload = function() {
        let errorMessage = JSON.parse(this.result.toString());
        console.log(errorMessage.token)
      };
      reader.readAsText(result.data)

    }, (error) => {
      let errorMessage = JSON.parse(error.response);
      console.log(errorMessage.message);
    });
    
  }

}

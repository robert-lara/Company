import { Component, OnInit } from '@angular/core';
import { faBars } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  host: {
    '(window:resize)': 'onResize($event)'
  }
})
export class HeaderComponent implements OnInit {

  showNavigation = true;
  isMobileDevice = false;
  faBars = faBars;
  constructor() { 
  }

  ngOnInit(): void {

    if (window.screen.width <= 411) {
      this.isMobileDevice = true;
      this.showNavigation = false;
    }else{
      this.isMobileDevice = false;
      this.showNavigation = true;
    }

  }

  onResize(event){

    //Set to 411 to cover iPhones and Pixels
    if (window.screen.width <= 411) {
      this.isMobileDevice = true;
      this.showNavigation = false;
    }else{
      this.isMobileDevice = false;
      this.showNavigation = true;
    }
  }

  logoClicked(){

    if(this.isMobileDevice){
      this.showNavigation = !this.showNavigation;
    }
  }

}

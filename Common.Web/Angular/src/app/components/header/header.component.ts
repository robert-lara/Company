import { Component, OnInit } from '@angular/core';

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
  isMobileDevice = true;
  constructor() { 
  }

  ngOnInit(): void {

    if (window.screen.width <= 375) {
      this.isMobileDevice = true;
    }else{
      this.isMobileDevice = false;
    }

  }

  onResize(event){
    if (window.screen.width <= 375) {
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

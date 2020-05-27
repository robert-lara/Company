import { Component, OnInit } from '@angular/core';
import { faBars } from '@fortawesome/free-solid-svg-icons';
import { animate, style, group, query, transition, trigger } from '@angular/animations';

@Component({
  selector: 'app-header',
  animations: [
    trigger('listItemAnimation', [
      transition(':enter', [
        style({ height: '0px', overflow: 'hidden' }),
        group([animate('250ms ease-out', style({ height: '!' }))]),
      ]),
      transition(':leave', [
        style({ height: '!', overflow: 'hidden' }),
        group([animate('250ms ease-out', style({ height: '0px' }))]),
      ]),
    ]),
  ],
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

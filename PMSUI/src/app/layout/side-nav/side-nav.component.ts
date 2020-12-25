import { Component, OnInit } from '@angular/core';


declare const $: any;

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent implements OnInit {
  public menuItems: any[] = [];
  constructor() { }

  ngOnInit(): void {
  }
  
  isMobileMenu() {
    if ($(window).width() > 991) {
        return false;
    }
    return true;
};

}

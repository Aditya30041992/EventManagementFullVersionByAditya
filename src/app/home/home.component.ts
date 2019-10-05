import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  template: `<div class="page-header">
  <div class="container">
  <div class="navLinks" align="center" >
        

        <a [routerLink]="['/homepage']"   class="btn btn-primary active">
        <i class="glyphicon glyphicon-floppy-disk" aria-hidden="true"></i>Home</a>

        <a [routerLink]="['/aboutus']"   class="btn btn-primary active">
        <i class="glyphicon glyphicon-floppy-disk" aria-hidden="true"></i>About Us</a>

        <a [routerLink]="['/contactus']"   class="btn btn-primary active">
        <i class="glyphicon glyphicon-floppy-disk" aria-hidden="true"></i>Contact Us</a>

        <a [routerLink]="['/admin']"   class="btn btn-primary active">
        <i class="glyphicon glyphicon-floppy-disk" aria-hidden="true"></i>Admin Login</a>

        <a [routerLink]="['/customer-login']"  class="btn btn-primary active">
        <i class="glyphicon glyphicon-floppy-disk" aria-hidden="true"></i>Customer Login</a>

        <a [routerLink]="['/customer-register']"  class="btn btn-primary active">
        <i class="glyphicon glyphicon-floppy-disk" aria-hidden="true"></i>Customer Register</a>

      </div>
  </div>
</div>

<div id="content">
  <div class="container">
      <router-outlet></router-outlet>
  </div>
</div>`,
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}

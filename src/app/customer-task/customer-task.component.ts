import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-customer-task',
  template: `<div class="page-header">
  <div class="container">
  
  <div class="navLinks" align="center">
  <h1 align="center" class="jumbotron bg-secondary text-white">Customer Dashboard</h1>
  <a [routerLink]="['/venue-list']"   class="btn btn-primary active">Show Venues</a>

        <a [routerLink]="['/booking-venue']"   class="btn btn-primary active">Book Venue</a>

        <a [routerLink]="['/show-booking-route']"  class="btn btn-primary active">Booking Status</a>

        <a [routerLink]="['/#']"  class="btn btn-primary active">
        <i class="glyphicon glyphicon-user" aria-hidden="true"></i>Profile</a>

        <a [routerLink]="['/change-password']"  class="btn btn-primary active">Change Password</a>

        <a [routerLink]="['/homepage']"  class="btn btn-primary active">
        <i class="glyphicon glyphicon-off" aria-hidden="true"></i>Logout</a>

        </div>
      <hr>
  </div>
</div>

<div id="content">
  <div class="container">
      <router-outlet></router-outlet>
  </div>
</div>`,
  styleUrls: ['./customer-task.component.css']
})
export class CustomerTaskComponent implements OnInit {
cid:number;
  constructor() { 
    this.cid = Number.parseInt(localStorage.getItem('id'));
    console.log(this.cid);
  }

  ngOnInit() {
  }

}

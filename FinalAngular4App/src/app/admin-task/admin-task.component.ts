import { Component } from '@angular/core';

@Component({
  selector: 'app-admin-task',
  template: `<div class="page-header">
  <div class="container">
  <h1 align="center" class="jumbotron bg-secondary text-white">Admin Dashboard</h1>
  <hr>
  <div class="navLinks" align="center">
  
        <a [routerLink]="['/add-venues']"   class="btn btn-primary active">Add Venue</a>

        <a [routerLink]="['/add-equipment']"  class="btn btn-primary active">Add Equipment</a>

        <a [routerLink]="['/add-flower']"  class="btn btn-primary active">Add Flower</a>

        <a [routerLink]="['/add-light']"  class="btn btn-primary active">Add Light</a>

        <a [routerLink]="['/add-food']"  class="btn btn-primary active">Add Food</a>

        <a [routerLink]="['/show-booking']"  class="btn btn-primary active">All Bookings </a>

        <a [routerLink]="['/customer-list']"  class="btn btn-primary active">
        <i class="glyphicon glyphicon-user" aria-hidden="true"></i>User Profiles</a>

        <a [routerLink]="['/homepage']"  class="btn btn-primary active" >
        <i class="glyphicon glyphicon-log-out" aria-hidden="true"></i>Logout</a>
        </div>
        <hr>
  </div>
</div>

<div id="content">
  <div class="container">
      <router-outlet></router-outlet>
  </div>
</div>` 
})
export class AdminTaskComponent {
        query:string;
}

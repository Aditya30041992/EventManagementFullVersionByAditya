import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from "@angular/router";
import {ToastrService} from 'ngx-toastr';
import { AdminService } from "./shared/admin.service";
import { Admin } from "./shared/admin.model";

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(private adminService :AdminService, private route: Router, private router: ActivatedRoute, private toaster: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?:NgForm){
    if(form != null)
    form.reset();
  this.adminService.adminLogin={
    Id : null,
    Email : "",
    Password : "",
    Name : "",
    Contact : null
  };
  }
 
  onSubmit(form:NgForm)
  {
  /*  this.customerService.auth(form.value).then((data) => {
      localStorage.setItem('UserToken', 'this.customerService.selectedCustomer.CustomerId');
      console.log(localStorage.getItem('UserToken'));
      console.log(this.customerService.selectedCustomer);
      form.reset();
      this.toaster.success("Welcome To Marraige Event Booking System..!!","Login Successfull...!!");*/
      this.route.navigate(['/admin-task'],{relativeTo : this.router}); 
 /*   },
    err => {
      localStorage.removeItem('UserToken');
      this.resetForm();
      this.toaster.error("Incorrect User OR Password","Invalid");
      form.reset();
    },);
    form.reset();*/
  }
  
}

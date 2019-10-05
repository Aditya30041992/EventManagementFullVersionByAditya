import { Component, OnInit } from '@angular/core';
import { AauthenticationService } from "../shared/aauthentication.service";
//import { CustomerService } from '../shared/customer.service';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from "@angular/router";
import {ToastrService} from 'ngx-toastr';
import { CustomerLogin } from "../shared/customer-login";
@Component({
  selector: 'app-customer-login',
  templateUrl: './customer-login.component.html',
  styleUrls: ['./customer-login.component.css']
})
export class CustomerLoginComponent implements OnInit {
//selectCustomerLogin:CustomerLogin;
 // selectcustomerlogin:CustomerLogin;
  model: any = {};
   loading = false;
  constructor(private authenticationService: AauthenticationService , 
    private route: Router, 
    private router: ActivatedRoute, 
    private toaster: ToastrService) { }


  ngOnInit() {
  
  }  
  
 
  login(form:NgForm) {
   /* this.loading = true;
    this.authenticationService.login(form.value.CustomerId , form.value.CustomerPassword)
        .subscribe(
            data => {
              localStorage.setItem('id', form.value.CustomerId);
              console.log(form.value.CustomerId);
              this.toaster.success("Welcome To Marraige Event Booking System..!!","Login Successfull...!!");
              this.router.navigate(['/customer-task'],{relativeTo : this.route}); 
            },
            error => {
              //  this.alertService.error(error);
                this.loading = false;
            });*/
           // localStorage.setItem('id', form.value.CustomerId);
           localStorage.setItem('id', form.value.CustomerId);
            console.log(form.value.CustomerId);
            this.toaster.success("Welcome To Marraige Event Booking System..!!","Login Successfull...!!");
            this.route.navigate(['/customer-task'],{relativeTo : this.router});
}


  /*onSubmit(form:NgForm)
  {
    this.customerService.getCustomerLogin(form.value.CustomerId, form.value.CustomerPassword)
    .subscribe(
      data =>{this.cust=data;
        this.toaster.success("Welcome To Marraige Event Booking System..!!","Login Successfull...!!");
        this.route.navigate(['/customer-task'],{relativeTo : this.router}); 
   
        this.found=true;},
      err =>{this.found=false;
        this.toaster.success("Invalide Username or Password..!!","Login Unsuccessfull...!!");
        this.route.navigate(['/customer-login'],{relativeTo : this.router}); 
  
      }
         )

    
  /*  this.status = this.customerService.postCustomerLogin(form.value);
    if(status == 'TRUE'){
      this.toaster.success("Welcome To Marraige Event Booking System..!!","Login Successfull...!!");
      this.route.navigate(['/customer-task'],{relativeTo : this.router}); 
    }
    else{
      this.toaster.success("Invalide Username or Password..!!","Login Unsuccessfull...!!");
      this.route.navigate(['/customer-login'],{relativeTo : this.router}); 
    }*/

    
  
  
}

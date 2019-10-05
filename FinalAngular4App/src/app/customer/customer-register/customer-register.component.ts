import { Component, OnInit } from '@angular/core';
import {CustomerService} from '../shared/customer.service';
import { NgForm } from '@angular/forms';
import {ToastrService} from 'ngx-toastr';
@Component({
  selector: 'app-customer-register',
  templateUrl: './customer-register.component.html',
  styleUrls: ['./customer-register.component.css']
})
export class CustomerRegisterComponent implements OnInit {

  constructor(private customerService :CustomerService,private toaster: ToastrService ) { }

  ngOnInit() {
    this.resetForm();

  }
resetForm(form?:NgForm){
  if(form != null)
  form.reset();
this.customerService.selectedCustomer={
  CustomerId:null,
  CustomerName:"",
  CustomerAddress:"",
  CustomerContact:null,
  CustomerCity:"",
  CustomerEmail:"",
  CustomerPassword:"",
  CustomerConfirmPassword:"",
  CustomerGender:""
}
}
onSubmit(form : NgForm){
  if(form.value.CustomerPassword == form.value.CustomerConfirmPassword){
  this.customerService.postCustomer(form.value)
  .subscribe(data => {
    this.resetForm(form);
    this.toaster.success('New Record Added Successfully', 'Customer Register');
  })
}
else{
  this.toaster.warning("Entered Password Missmatched..!!","Registration Failed..!!");
}
}


}


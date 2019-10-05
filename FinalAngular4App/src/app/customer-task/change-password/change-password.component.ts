import { Component, OnInit } from '@angular/core';
import {CustomerTaskService} from '../shared/customer-task.service';
import {NgForm} from '@angular/forms';
import{ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {

  constructor(private customerTaskService :CustomerTaskService, private toaster: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?:NgForm){
    if(form != null)
    form.reset();
  this.customerTaskService.selectedChangePass={
    CustomerId:null,
    CustomerPassword:"",
    CustomerNewPassword:"",
    CustomerConfirmPassword:""
  }
  }

  onSubmit(form : NgForm){
    this.customerTaskService.postChangePassword(form.value)
    .subscribe(data => {
      this.resetForm(form);
      this.toaster.success("Password Change Successfull..!!","Password Changed..!!");
    })
  }

}

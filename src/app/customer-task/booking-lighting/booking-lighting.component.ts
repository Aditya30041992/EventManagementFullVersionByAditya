import { Component, OnInit } from '@angular/core';
import {CustomerTaskService} from '../shared/customer-task.service';
import {NgForm} from '@angular/forms';
import{ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-booking-lighting',
  templateUrl: './booking-lighting.component.html',
  styleUrls: ['./booking-lighting.component.css']
})
export class BookingLightingComponent implements OnInit {
cid:number;
  constructor(private customerTaskService :CustomerTaskService, private toaster: ToastrService) {
    this.cid = Number.parseInt(localStorage.getItem('id'));
    console.log(this.cid); }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?:NgForm){
    if(form != null)
    form.reset();
  this.customerTaskService.selectedLight={
    //LightId : null,
    LightType : "",
    LightNameID : "",
    CustomerId : this.cid
  }
  }

  onSubmit(form : NgForm){
    this.customerTaskService.postBookLighting(form.value)
    .subscribe(data => {
      //this.resetForm(form);
      this.toaster.success("Lighting Booked Successfull..!!","Lighting added to List..!!");
    })
  }


}

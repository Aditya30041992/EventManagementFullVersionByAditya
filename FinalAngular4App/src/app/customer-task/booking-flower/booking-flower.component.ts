import { Component, OnInit } from '@angular/core';
import {CustomerTaskService} from '../shared/customer-task.service';
import {NgForm} from '@angular/forms';
import{ToastrService} from 'ngx-toastr';
@Component({
  selector: 'app-booking-flower',
  templateUrl: './booking-flower.component.html',
  styleUrls: ['./booking-flower.component.css']
})
export class BookingFlowerComponent implements OnInit {
  cid:number;

  constructor(private customerTaskService :CustomerTaskService, private toaster: ToastrService) {
    this.cid = Number.parseInt(localStorage.getItem('id'));
    console.log(this.cid);
   }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?:NgForm){
    if(form != null)
    form.reset();
  this.customerTaskService.selectedBookFlower={
    FlowerId : "",
    CustomerId : this.cid
  }
  }

  onSubmit(form : NgForm){
    this.customerTaskService.postBookFlower(form.value)
    .subscribe(data => {
      //this.resetForm(form);
      this.toaster.success("Flowers Booked Successfull..!!","Flower added to list..!!");
    })
  }



}

import { Component, OnInit } from '@angular/core';
import {CustomerTaskService} from '../shared/customer-task.service';
import {NgForm} from '@angular/forms';
import{ToastrService} from 'ngx-toastr';
@Component({
  selector: 'app-booking-equipment',
  templateUrl: './booking-equipment.component.html',
  styleUrls: ['./booking-equipment.component.css']
})
export class BookingEquipmentComponent implements OnInit {
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
  this.customerTaskService.selectedBookEquipment={
    EquipmentId : "",
    CustomerId : this.cid
  }
  }

  onSubmit(form : NgForm){
    this.customerTaskService.postBookEquipment(form.value)
    .subscribe(data => {
     // this.resetForm(form);
      this.toaster.success("Equipment Booked Successfull..!!","Equipment added to list..!!");
    })
  }

}

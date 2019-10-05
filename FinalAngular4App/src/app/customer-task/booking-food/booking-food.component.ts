import { Component, OnInit } from '@angular/core';
import {CustomerTaskService} from '../shared/customer-task.service';
import {NgForm} from '@angular/forms';
import{ToastrService} from 'ngx-toastr';
@Component({
  selector: 'app-booking-food',
  templateUrl: './booking-food.component.html',
  styleUrls: ['./booking-food.component.css']
})
export class BookingFoodComponent implements OnInit {
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
  this.customerTaskService.selectedBookFood={
    //FoodId : null,
    FoodType : "",
    MealType : "",
    DishType : "",
    DishName : "",
    CustomerId : this.cid
  }
  }

  onSubmit(form : NgForm){
    this.customerTaskService.postBookFood(form.value)
    .subscribe(data => {
      //this.resetForm(form);
      this.toaster.success("Food Order Successfull..!!","Food added to List..!!");
    })
  }

}

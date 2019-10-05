import { Component, OnInit } from '@angular/core';
import { VenueService } from '../Shared/venue.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-edit-food',
  templateUrl: './edit-food.component.html',
  styleUrls: ['./edit-food.component.css']
})
export class EditFoodComponent implements OnInit {

  constructor(private adminTaskService :VenueService, private toaster: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?:NgForm){
    if(form != null)
    form.reset();
  this.adminTaskService.selectedFood={
    FoodId : "",
    //FoodType : "",
    //MealType : "",
    //DishType : "",
    FoodName : "",
    //FoodFileName : "",
    //FoodFilePath : "",
//    CreatedBy : "",
    FoodCost : null

  }
  }

  onSubmit(form : NgForm){
    this.adminTaskService.putFood(form.value.FoodId, form.value)
    .subscribe(data => {
      this.resetForm(form);
      this.adminTaskService.getFoodList();
      this.toaster.success("Record Updated Successfull..!!","Food Updated..!!");
    })
  }
}

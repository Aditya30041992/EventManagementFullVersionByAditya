import { Component, OnInit } from '@angular/core';
import { VenueService } from '../Shared/venue.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-edit-flower',
  templateUrl: './edit-flower.component.html',
  styleUrls: ['./edit-flower.component.css']
})
export class EditFlowerComponent implements OnInit {

  constructor(private adminTaskService :VenueService, private toaster: ToastrService) { }

  ngOnInit() {
    this.resetForm();  
  }

  resetForm(form?:NgForm){
    if(form != null)
    form.reset();
  this.adminTaskService.selectedFlower={
    FlowerId : "",
    FlowerName : "",
   // FlowerFileName : "",
    //FlowerFilePath : "",
    FlowerCost : null
//    FlowerCreatedBy : string;
  }
  }

  onSubmit(form : NgForm){
    this.adminTaskService.putFlower(form.value.FlowerId, form.value)
    .subscribe(data => {
      this.resetForm(form);
      this.adminTaskService.getFlowerList();
      this.toaster.success("Record Updated Successfull..!!","Flower Updated..!!");
    })
  }
}

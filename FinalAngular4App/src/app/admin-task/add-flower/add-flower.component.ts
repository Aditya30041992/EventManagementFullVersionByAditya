import { Component, OnInit } from '@angular/core';
import { VenueService } from '../Shared/venue.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-flower',
  templateUrl: './add-flower.component.html',
  styleUrls: ['./add-flower.component.css']
})
export class AddFlowerComponent implements OnInit {

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
    //FlowerFileName : "",
    //FlowerFilePath : "",
    FlowerCost : null
//    FlowerCreatedBy : string;
  }
  }

  onSubmit(form : NgForm){
    this.adminTaskService.postFlower(form.value)
    .subscribe(data => {
      this.resetForm(form);
      this.adminTaskService.getFlowerList();
      this.toaster.success("Flower Added Successfull..!!","Flower Inserted..!!");
    })
  }
}

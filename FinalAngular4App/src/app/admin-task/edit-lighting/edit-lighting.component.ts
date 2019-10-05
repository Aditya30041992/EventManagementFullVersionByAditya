import { Component, OnInit } from '@angular/core';
import { VenueService } from '../Shared/venue.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-edit-lighting',
  templateUrl: './edit-lighting.component.html',
  styleUrls: ['./edit-lighting.component.css']
})
export class EditLightingComponent implements OnInit {

  constructor(private adminTaskService :VenueService, private toaster: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?:NgForm){
    if(form != null)
    form.reset();
  this.adminTaskService.selectedLight={
    LightId : "",
    //LightType : "",
    LightName : "",
   // LightFileName : "",
    //LightFilePath : "",
    LightCost : null
  //  LightCreatedBy : ""
  }
  }
  onSubmit(form : NgForm){
    this.adminTaskService.putLighting(form.value.LightId, form.value)
    .subscribe(data => {
      this.resetForm(form);
      this.adminTaskService.getLightList();
      this.toaster.success("Record Updated Successfull..!!","Lighting Updated..!!");
    })
  }

}

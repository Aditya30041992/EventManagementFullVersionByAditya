import { Component, OnInit } from '@angular/core';
import { VenueService } from '../Shared/venue.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-edit-venue',
  templateUrl: './edit-venue.component.html',
  styleUrls: ['./edit-venue.component.css']
})
export class EditVenueComponent implements OnInit {

  constructor(private adminTaskService :VenueService, private toaster: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?:NgForm){
    if(form != null)
    form.reset();
  this.adminTaskService.selectedVenue={
    VenueId : "",
    VenueName : "",
   // VenueFileName : "",
    //VenueFilePath : "",
    VenueCost : null,
 //   VenueCreatedBy :null,
    VenueCapacity : null,
    VenueContact : null,
    VenueAddress : ""
  }
  }

  onSubmit(form : NgForm){
      this.adminTaskService.putVenue(form.value.VenueId, form.value)
      .subscribe(data => {
      this.resetForm(form);
      this.adminTaskService.getVenueList();
      this.toaster.success("Record Updated Successfull..!!","Venue Updated..!!");
     })
  }
}
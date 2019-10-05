import { Component, OnInit } from '@angular/core';
import { VenueService } from '../Shared/venue.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-venues',
  templateUrl: './add-venues.component.html',
  styleUrls: ['./add-venues.component.css']
})
export class AddVenuesComponent implements OnInit {

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
    //VenueFileName : "",
    //VenueFilePath : "",
    VenueCost : null,
 //   VenueCreatedBy :null,
    VenueCapacity : null,
    VenueContact : null,
    VenueAddress : ""
  }
  }

  onSubmit(form : NgForm){
    this.adminTaskService.postVenue(form.value)
    .subscribe(data => {
      this.resetForm(form);
      this.toaster.success("Venue Registration Successfull..!!","Venue Booked..!!");
    })
  }
}
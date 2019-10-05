import { Component, OnInit } from '@angular/core';
import {CustomerTaskService} from '../shared/customer-task.service';
import { Router, ActivatedRoute } from "@angular/router";
import {NgForm} from '@angular/forms';
import{ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-booking-venue',
  templateUrl: './booking-venue.component.html',
  styleUrls: ['./booking-venue.component.css']
})
export class BookingVenueComponent implements OnInit {
cid:number;

  constructor(private customerTaskService :CustomerTaskService, private toaster: ToastrService,private route: Router, private router: ActivatedRoute) { 
    this.cid = Number.parseInt(localStorage.getItem('id'));
   // console.log(this.cid);

  }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?:NgForm){
    if(form != null)
    form.reset();
  this.customerTaskService.selectedBookVenue={
    VenueId : "",
    EventTypeId : null,
    GuestCount : null,
    BookDate : null,
    CustomerId : null
  }
  }

  onSubmit(form : NgForm){
   
    this.customerTaskService.postBookVenue(form.value)
    .subscribe(data => {
     // this.resetForm(form);
      this.toaster.success("Venue Booked Successfull..!!","Venue added to list..!!");
      this.route.navigate(['/booking-equipment'],{relativeTo : this.router}); 
    })
  }

}

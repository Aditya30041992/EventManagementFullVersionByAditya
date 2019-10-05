import { Component, OnInit } from '@angular/core';
import{VenueService} from '../Shared/venue.service';
import { Showbooking } from "../Shared/showbooking.model";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: 'app-show-booking',
  templateUrl: './show-booking.component.html',
  styleUrls: ['./show-booking.component.css']
})
export class ShowBookingComponent implements OnInit {

  constructor(private adminService:VenueService, private toastr : ToastrService) { }

  ngOnInit() {
    this.adminService.getBooking();
  }

}

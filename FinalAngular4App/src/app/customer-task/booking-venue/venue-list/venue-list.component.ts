import { Component, OnInit } from '@angular/core';
import { VenueService } from "../../../admin-task/Shared/venue.service";
import {  } from "../../../admin-task/Shared/venue.model";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: 'app-venue-list',
  templateUrl: './venue-list.component.html',
  styleUrls: ['./venue-list.component.css']
})
export class VenueListComponent implements OnInit {

  constructor(private customerService:VenueService, private toastr : ToastrService) { }

  ngOnInit() {
    this.customerService.getVenueList();
  }

}

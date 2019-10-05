import { Component, OnInit } from '@angular/core';
import{VenueService} from '../Shared/venue.service';
import{Venue} from '../Shared/venue.model';
import { ToastrService } from "ngx-toastr";

@Component({
  selector: 'app-show-venue',
  templateUrl: './show-venue.component.html',
  styleUrls: ['./show-venue.component.css']
})
export class ShowVenueComponent implements OnInit {

  constructor(private adminService:VenueService, private toastr : ToastrService) { }

  ngOnInit() {
    this.adminService.getVenueList();
  }

  editVenue(venue:Venue){
    this.adminService.selectedVenue = Object.assign({},venue);
  }

  onDeleteVenue(id : number){
    if(confirm('Are you sure to delete this record ?') == true){
      this.adminService.deleteVenueList(id)
      .subscribe(x => {
        this.adminService.getVenueList();
        this.toastr.warning("Record Deleted Successfully...!!!","Venue Deleted..!!")
      })
    }

  }


}

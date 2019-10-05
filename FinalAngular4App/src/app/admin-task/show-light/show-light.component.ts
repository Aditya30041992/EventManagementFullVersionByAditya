import { Component, OnInit } from '@angular/core';
import{VenueService} from '../Shared/venue.service';
import{Light} from '../Shared/light.model';
import { ToastrService } from "ngx-toastr";

@Component({
  selector: 'app-show-light',
  templateUrl: './show-light.component.html',
  styleUrls: ['./show-light.component.css']
})
export class ShowLightComponent implements OnInit {

  constructor(private adminService:VenueService, private toastr : ToastrService) { }

  ngOnInit() {
    this.adminService.getLightList();
  }
  editLighting(light:Light){
    this.adminService.selectedLight = Object.assign({},light);
  }

  onDeleteLighting(id : number){
    if(confirm('Are you sure to delete this record ?') == true){
      this.adminService.deleteLightingList(id)
      .subscribe(x => {
        this.adminService.getLightList();
        this.toastr.warning("Record Deleted Successfully...!!!","Lighting Deleted..!!")
      })
    }
  }



}

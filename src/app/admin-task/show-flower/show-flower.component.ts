import { Component, OnInit } from '@angular/core';
import{VenueService} from '../Shared/venue.service';
import{Flower} from '../Shared/flower.model';
import { ToastrService } from "ngx-toastr";


@Component({
  selector: 'app-show-flower',
  templateUrl: './show-flower.component.html',
  styleUrls: ['./show-flower.component.css']
})
export class ShowFlowerComponent implements OnInit {

  constructor(private adminService:VenueService, private toastr : ToastrService) { }

  ngOnInit() {
    this.adminService.getFlowerList();
  }

  editFlower(flw:Flower){
    this.adminService.selectedFlower = Object.assign({},flw);
  }

  onDeleteFlower(id : number){
    if(confirm('Are you sure to delete this record ?') == true){
      this.adminService.deleteFlowerList(id)
      .subscribe(x => {
        this.adminService.getFlowerList();
        this.toastr.warning("Record Deleted Successfully...!!!","Flower Deleted..!!")
      })
    }
  }

}

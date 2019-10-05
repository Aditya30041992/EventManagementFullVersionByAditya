import { Component, OnInit } from '@angular/core';
import{VenueService} from '../Shared/venue.service';
import{Equipment} from '../Shared/equipment.model';
import { ToastrService } from "ngx-toastr";
@Component({
  selector: 'app-show-equipment',
  templateUrl: './show-equipment.component.html',
  styleUrls: ['./show-equipment.component.css']
})
export class ShowEquipmentComponent implements OnInit {

  constructor(private adminService:VenueService, private toastr : ToastrService ) { }

  ngOnInit() {
    this.adminService.getEquipmentList();
  }

  editEquipment(eqp:Equipment){
    this.adminService.selectedEquipment = Object.assign({},eqp);
  }

  onDeleteEquipment(id : number){
    if(confirm('Are you sure to delete this record ?') == true){
      this.adminService.deleteEquipmentList(id)
      .subscribe(x => {
        this.adminService.getEquipmentList();
        this.toastr.warning("Record Deleted Successfully...!!!","Equipment Deleted..!!")
      })
    }
  }

}

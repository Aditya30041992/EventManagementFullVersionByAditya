import { Component, OnInit } from '@angular/core';
import { ToastrService } from "ngx-toastr";
import { CustomerTaskService } from "../shared/customer-task.service";
import { Showflower } from "../shared/showflower.model";
import { Showvenue } from "../shared/showvenue.model";
import { Showlight } from "../shared/showlight.model";
import { Showfood } from "../shared/showfood.model";
import { Showequipment } from "../shared/showequipment.model";
@Component({
  selector: 'app-display-all-bookings',
  templateUrl: './display-all-bookings.component.html',
  styleUrls: ['./display-all-bookings.component.css']
})
export class DisplayAllBookingsComponent implements OnInit {
  cid:number;
  constructor( private customerService:CustomerTaskService, private toastr : ToastrService) {
    this.cid = Number.parseInt(localStorage.getItem('id'));

   }
  ngOnInit() {
    this.customerService.getVenueList(this.cid);
    this.customerService.getEquipmentList(this.cid);
    this.customerService.getFlowerList(this.cid);
    this.customerService.getFoodList(this.cid);
    this.customerService.getLightList(this.cid);
  }

  onDeleteEquipment(id : number){
    if(confirm('Are you sure to delete this record ?') == true){
      this.customerService.deleteEquipmentList(this.cid)
      .subscribe(x => {
        this.customerService.getEquipmentList(this.cid);
        this.toastr.warning("Record Deleted Successfully...!!!","Equipment Deleted..!!")
      })
    }
  }

  onDeleteFlower(id : number){
    if(confirm('Are you sure to delete this record ?') == true){
      this.customerService.deleteFlowerList(this.cid)
      .subscribe(x => {
        this.customerService.getFlowerList(this.cid);
        this.toastr.warning("Record Deleted Successfully...!!!","Flower Deleted..!!")
      })
    }
  }

  onDeleteFood(id : number){
    if(confirm('Are you sure to delete this record ?') == true){
      this.customerService.deleteFoodList(this.cid)
      .subscribe(x => {
        this.customerService.getFoodList(this.cid);
        this.toastr.warning("Record Deleted Successfully...!!!","Food Deleted..!!")
      })
    }
  }

  onDeleteLight(id : number){
    if(confirm('Are you sure to delete this record ?') == true){
      this.customerService.deleteLightingList(this.cid)
      .subscribe(x => {
        this.customerService.getLightList(this.cid);
        this.toastr.warning("Record Deleted Successfully...!!!","Light Deleted..!!")
      })
    }
  }

  onDeleteVenue(id : number){
    if(confirm('Are you sure to delete this record ?') == true){
      this.customerService.deleteVenueList(this.cid)
      .subscribe(x => {
        this.customerService.getVenueList(this.cid);
        this.toastr.warning("Record Deleted Successfully...!!!","Venue Deleted..!!")
      })
    }
  }



}

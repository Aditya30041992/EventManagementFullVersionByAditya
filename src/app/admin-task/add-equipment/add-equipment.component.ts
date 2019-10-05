import { Component, OnInit } from '@angular/core';
import { VenueService } from '../Shared/venue.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-equipment',
  templateUrl: './add-equipment.component.html',
  styleUrls: ['./add-equipment.component.css']
})
export class AddEquipmentComponent implements OnInit {

  constructor(private adminTaskService :VenueService, private toaster: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }
  
  resetForm(form?:NgForm){
    if(form != null)
    form.reset();
  this.adminTaskService.selectedEquipment={
    EquipmentId : "",
    EquipmentName : "",
    //EquipmentFileName :"",
    //EquipmentFilePath : "",
    EquipmentCost : null
   // EquipmentCreatedBy : ""
  }
  }

  onSubmit(form : NgForm){
    this.adminTaskService.postEquipment(form.value)
    .subscribe(data => {
      this.resetForm(form);
      this.adminTaskService.getEquipmentList();
      this.toaster.success("Equipment Added Successfull..!!","Equipment Inserted..!!");
    })
  }
}

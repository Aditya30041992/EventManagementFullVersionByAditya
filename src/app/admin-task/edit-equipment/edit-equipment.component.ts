import { Component, OnInit } from '@angular/core';
import { VenueService } from '../Shared/venue.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edit-equipment',
  templateUrl: './edit-equipment.component.html',
  styleUrls: ['./edit-equipment.component.css']
})
export class EditEquipmentComponent implements OnInit {

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
   // EquipmentFileName :"",
    //EquipmentFilePath : "",
    EquipmentCost : null
   // EquipmentCreatedBy : ""
  }
  }

  onSubmit(form : NgForm){
    this.adminTaskService.putEquipment(form.value.EquipmentId, form.value)
    .subscribe(data => {
      this.resetForm(form);
      this.adminTaskService.getEquipmentList();
      this.toaster.success("Record Updated Successfull..!!","Equipment Updated..!!");
    })

  
  }

}

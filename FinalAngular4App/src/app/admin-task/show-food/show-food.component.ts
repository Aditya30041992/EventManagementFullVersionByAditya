import { Component, OnInit } from '@angular/core';
import{VenueService} from '../Shared/venue.service';
import{Food} from '../Shared/food.model';
import { ToastrService } from "ngx-toastr";


@Component({
  selector: 'app-show-food',
  templateUrl: './show-food.component.html',
  styleUrls: ['./show-food.component.css']
})
export class ShowFoodComponent implements OnInit {

  constructor(private adminService:VenueService, private toastr : ToastrService ) { }

  ngOnInit() {
    this.adminService.getFoodList();
  }
  editFood(food:Food){
    this.adminService.selectedFood = Object.assign({},food);
  }

  onDeleteFood(id : number){
    if(confirm('Are you sure to delete this record ?') == true){
      this.adminService.deleteFoodList(id)
      .subscribe(x => {
        this.adminService.getFoodList();
        this.toastr.warning("Record Deleted Successfully...!!!","Food Deleted..!!")
      })
    }

  }

}

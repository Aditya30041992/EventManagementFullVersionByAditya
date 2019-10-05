import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import{Observable} from 'rxjs/Observable';
import "rxjs/add/operator/map";
import "rxjs/add/operator/toPromise";
import { Venue } from "./venue.model";
import { Equipment } from './equipment.model';
import { Flower } from './flower.model';
import { Food } from './food.model';
import { Light } from './light.model';
import { Showbooking } from './showbooking.model';
@Injectable()
export class VenueService {
  selectedVenue:Venue;
  selectedEquipment:Equipment;
  selectedFlower:Flower;
  selectedFood:Food;
  selectedLight:Light;
  showVenue:Venue[];
  showEquipment:Equipment[];
  showFlower:Flower[];
  showFood:Food[];
  showLight:Light[];
  showBookings : Showbooking[];

  constructor(private http:Http) { }

//Inserting data into database
  postVenue(venue:Venue){
    var body=JSON.stringify(venue);
    var headerOptions =new Headers({'Content-Type':'application/json'});
    var requestOptions=new RequestOptions({method:RequestMethod.Post, headers:headerOptions});
    return this.http.post('http://localhost:49637/api/VenueDetails',body,requestOptions).map(x => x.json());
  }

  postEquipment(eqp:Equipment){
    var body=JSON.stringify(eqp);
    var headerOptions =new Headers({'Content-Type':'application/json'});
    var requestOptions=new RequestOptions({method:RequestMethod.Post, headers:headerOptions});
    return this.http.post('http://localhost:49637/api/EquipmentDetails',body,requestOptions).map(x => x.json());
  }

   postFlower(flw:Flower){
    var body=JSON.stringify(flw);
    var headerOptions =new Headers({'Content-Type':'application/json'});
    var requestOptions=new RequestOptions({method:RequestMethod.Post, headers:headerOptions});
    return this.http.post('http://localhost:49637/api/FlowerDetails',body,requestOptions).map(x => x.json());
  }

  postFood(food:Food){
    var body=JSON.stringify(food);
    var headerOptions =new Headers({'Content-Type':'application/json'});
    var requestOptions=new RequestOptions({method:RequestMethod.Post, headers:headerOptions});
    return this.http.post('http://localhost:49637/api/FoodDetails',body,requestOptions).map(x => x.json());
  }  

  postLighting(light:Light){
    var body=JSON.stringify(light);
    var headerOptions =new Headers({'Content-Type':'application/json'});
    var requestOptions=new RequestOptions({method:RequestMethod.Post, headers:headerOptions});
    return this.http.post('http://localhost:49637/api/LightDetails',body,requestOptions).map(x => x.json());
  }
  
  getVenueList(){
    this.http.get('http://localhost:49637/api/VenueDetails')
    .map((data : Response) =>{
      return data.json() as Venue[];
    }).toPromise().then(x => {
      this.showVenue = x;
    })
  }

//Getting data from database
  getEquipmentList(){
    this.http.get('http://localhost:49637/api/EquipmentDetails')
    .map((data : Response) =>{
      return data.json() as Equipment[];
    }).toPromise().then(x => {
      this.showEquipment = x;
    })
  }
  
  getFlowerList(){
    this.http.get('http://localhost:49637/api/FlowerDetails')
    .map((data : Response) =>{
      return data.json() as Flower[];
    }).toPromise().then(x => {
      this.showFlower = x;
    })
  }
  
  getFoodList(){
    this.http.get('http://localhost:49637/api/FoodDetails')
    .map((data : Response) =>{
      return data.json() as Food[];
    }).toPromise().then(x => {
      this.showFood = x;
    })
  }
  
  getLightList(){
    this.http.get('http://localhost:49637/api/LightDetails')
    .map((data : Response) =>{
      return data.json() as Light[];
    }).toPromise().then(x => {
      this.showLight = x;
    })
  }

  getBooking(){
    this.http.get('http://localhost:49637/api/BookingDetails')
    .map((data : Response) =>{
      return data.json() as Showbooking[];
    }).toPromise().then(x => {
      this.showBookings = x;
    })
  }


  
  //updating data of database 
  putEquipment(id, eqp){
    var body=JSON.stringify(eqp);
    var headerOptions =new Headers({'Content-Type':'application/json'});
    var requestOptions=new RequestOptions({method:RequestMethod.Put, headers:headerOptions});
    return this.http.put('http://localhost:49637/api/EquipmentDetails/' + id,
    body,
    requestOptions).map(res => res.json());
  }

  putVenue(id, venue){
    var body=JSON.stringify(venue);
    var headerOptions =new Headers({'Content-Type':'application/json'});
    var requestOptions=new RequestOptions({method:RequestMethod.Put, headers:headerOptions});
    return this.http.put('http://localhost:49637/api/VenueDetails/' + id,
    body,
    requestOptions).map(res => res.json());
  }

  putFood(id, food){
    var body=JSON.stringify(food);
    var headerOptions =new Headers({'Content-Type':'application/json'});
    var requestOptions=new RequestOptions({method:RequestMethod.Put, headers:headerOptions});
    return this.http.put('http://localhost:49637/api/FoodDetails/' + id,
    body,
    requestOptions).map(res => res.json());
  }

  putFlower(id, flw){
    var body=JSON.stringify(flw);
    var headerOptions =new Headers({'Content-Type':'application/json'});
    var requestOptions=new RequestOptions({method:RequestMethod.Put, headers:headerOptions});
    return this.http.put('http://localhost:49637/api/FlowerDetails/' + id,
    body,
    requestOptions).map(res => res.json());
  }

  putLighting(id, light){
    var body=JSON.stringify(light);
    var headerOptions =new Headers({'Content-Type':'application/json'});
    var requestOptions=new RequestOptions({method:RequestMethod.Put, headers:headerOptions});
    return this.http.put('http://localhost:49637/api/LightDetails/' + id,
    body,
    requestOptions).map(res => res.json());
  }

  //Deleting data from database
  deleteEquipmentList(id:number){
    return this.http.delete('http://localhost:49637/api/EquipmentDetails/' + id).map(res => res.json()); 
  }

  deleteVenueList(id:number){
    return this.http.delete('http://localhost:49637/api/VenueDetails/' + id).map(res => res.json()); 
  }

  deleteFlowerList(id:number){
    return this.http.delete('http://localhost:49637/api/FlowerDetails/' + id).map(res => res.json()); 
  }

  deleteFoodList(id:number){
    return this.http.delete('http://localhost:49637/api/FoodDetails/' + id).map(res => res.json()); 
  }

  deleteLightingList(id:number){
    return this.http.delete('http://localhost:49637/api/LightDetails/' + id).map(res => res.json()); 
  }

}

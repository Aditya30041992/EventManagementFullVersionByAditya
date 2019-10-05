import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import{Observable} from 'rxjs/Observable';
import "rxjs/add/operator/map";
import "rxjs/add/operator/toPromise";
import { Bookequipment } from './bookequipment.model';
import { Bookflower } from './bookflower.model';
import { Bookfood } from './bookfood.model';
import { Booklighting } from './booklighting.model';
import { Bookvenue } from './bookvenue.model';
import { Changepassword } from './changepassword.model';
import { Showvenue } from './showvenue.model';
import { Showflower } from './showflower.model';
import { Showequipment } from './showequipment.model';
import { Showfood } from './showfood.model';
import { Showlight } from './showlight.model';

@Injectable()
export class CustomerTaskService {
  bookVenue : Showvenue[];
  bookFlower : Showflower[];
  bookEqp : Showequipment[];
  bookFood: Showfood[];
  bookLight : Showlight[];  
  selectedBookVenue:Bookvenue;
  selectedBookEquipment:Bookequipment;
  selectedBookFlower:Bookflower;
  selectedBookFood:Bookfood;
  selectedLight:Booklighting;
  selectedChangePass:Changepassword;
  
  constructor(private http:Http ) { }

  postBookVenue(bookVenue:Bookvenue){
    var body=JSON.stringify(bookVenue);
    var headerOptions =new Headers({'Content-Type':'application/json'});
    var requestOptions=new RequestOptions({method:RequestMethod.Post, headers:headerOptions});
    return this.http.post('http://localhost:49637/api/BookingVenue',body,requestOptions).map(x => x.json());
  }

  postBookEquipment(bookEqp:Bookequipment){
    var body=JSON.stringify(bookEqp);
    var headerOptions =new Headers({'Content-Type':'application/json'});
    var requestOptions=new RequestOptions({method:RequestMethod.Post, headers:headerOptions});
    return this.http.post('http://localhost:49637/api/BookingEquipment',body,requestOptions).map(x => x.json());
  }

  postBookFlower(bookFlw:Bookflower){
    var body=JSON.stringify(bookFlw);
    var headerOptions =new Headers({'Content-Type':'application/json'});
    var requestOptions=new RequestOptions({method:RequestMethod.Post, headers:headerOptions});
    return this.http.post('http://localhost:49637/api/BookingFlower',body,requestOptions).map(x => x.json());
  }

  postBookFood(bookFood:Bookfood){
    var body=JSON.stringify(bookFood);
    var headerOptions =new Headers({'Content-Type':'application/json'});
    var requestOptions=new RequestOptions({method:RequestMethod.Post, headers:headerOptions});
    return this.http.post('http://localhost:49637/api/BookingFood',body,requestOptions).map(x => x.json());
  }  

  postBookLighting(bookLight:Booklighting){
    var body=JSON.stringify(bookLight);
    var headerOptions =new Headers({'Content-Type':'application/json'});
    var requestOptions=new RequestOptions({method:RequestMethod.Post, headers:headerOptions});
    return this.http.post('http://localhost:49637/api/BookingLight',body,requestOptions).map(x => x.json());
  }


  postChangePassword(changePass:Changepassword){
    var body=JSON.stringify(changePass);
    var headerOptions =new Headers({'Content-Type':'application/json'});
    var requestOptions=new RequestOptions({method:RequestMethod.Post, headers:headerOptions});
    return this.http.post('http://localhost:49637/',body,requestOptions).map(x => x.json());
  }

//Getting data from database

  getVenueList(id:number){
    this.http.get('http://localhost:49637/api/VenueDetails/'+id)
    .map((data : Response) =>{
      return data.json() as Showvenue[];
    }).toPromise().then(x => {
      this.bookVenue = x;
    })
  }

  getEquipmentList(id:number){
    this.http.get('http://localhost:49637/api/EquipmentDetails/'+id)
    .map((data : Response) =>{
      return data.json() as Showequipment[];
    }).toPromise().then(x => {
      this.bookEqp = x;
    })
  }
  
  getFlowerList(id:number){
    this.http.get('http://localhost:49637/api/FlowerDetails/'+id)
    .map((data : Response) =>{
      return data.json() as Showflower[];
    }).toPromise().then(x => {
      this.bookFlower = x;
    })
  }
  
  getFoodList(id:number){
    this.http.get('http://localhost:49637/api/FoodDetails/'+id)
    .map((data : Response) =>{
      return data.json() as Showfood[];
    }).toPromise().then(x => {
      this.bookFood = x;
    })
  }
  
  getLightList(id:number){
    this.http.get('http://localhost:49637/api/LightDetails/'+id)
    .map((data : Response) =>{
      return data.json() as Showlight[];
    }).toPromise().then(x => {
      this.bookLight = x;
    })
  }


  deleteEquipmentList(id:number){
    return this.http.delete('http://localhost:49637/api/BookingEquipment/' + id).map(res => res.json()); 
  }

  deleteVenueList(id:number){
    return this.http.delete('http://localhost:49637/api/BookingVenue/' + id).map(res => res.json()); 
  }

  deleteFlowerList(id:number){
    return this.http.delete('http://localhost:49637/api/BookingFlower/' + id).map(res => res.json()); 
  }

  deleteFoodList(id:number){
    return this.http.delete('http://localhost:49637/api/BookingFood/' + id).map(res => res.json()); 
  }

  deleteLightingList(id:number){
    return this.http.delete('http://localhost:49637/api/BookingLight/' + id).map(res => res.json()); 
  }





}

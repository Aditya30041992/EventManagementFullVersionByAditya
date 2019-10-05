import { Injectable } from '@angular/core';
import {Http, Response, Headers, RequestOptions, RequestMethod, Request } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import {ToastrService} from 'ngx-toastr';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import {Customer} from './customer.model'
import { CustomerLogin } from "./customer-login";
import { Router, ActivatedRoute } from '@angular/router';
@Injectable()
export class CustomerService {
selectedCustomer:Customer;
customerList : Customer[];
customerlogin:CustomerLogin;
constructor(private http : Http,private toaster: ToastrService, private route: Router, private router: ActivatedRoute) { }

/*auth(customerlogin:CustomerLogin){
  const body = JSON.stringify(customerlogin);
  const headerOptions = new Headers({'Content-Type':'application/json'});
  const requestOptions = new RequestOptions({method: RequestMethod.Post, headers:headerOptions});
  return this.http.post('http://localhost:49637/api/Validate',body,requestOptions).map((data:Response) => {
    return data.json() as Customer;
  }).toPromise().then(x => {
    this.selectedCustomer = x;
  })
}*/

/*getCustomerLogin(id:number, pass:string){
  return this.http.get('http://localhost:49637/api/CustomerRegister/'+id,pass)
  .map((data : Response) =>
   data.json())
}*/


postCustomer(cust : Customer){
  var body=JSON.stringify(cust);
  var headerOptions= new Headers({'Content-Type':'application/json'});
  var requestOptions = new RequestOptions({method :RequestMethod.Post, headers : headerOptions});
  return this.http.post('http://localhost:49637/api/CustomerRegister',body,requestOptions).map(x => x.json());
}

getCustomerList(){
  this.http.get('http://localhost:49637/api/CustomerRegister')
  .map((data : Response) =>{
    return data.json() as Customer[];
  }).toPromise().then(x => {
    this.customerList = x;
  })
}

}

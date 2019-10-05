import { Injectable } from '@angular/core';
import {Http, Response, Headers, RequestOptions, RequestMethod, Request } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Admin } from "./admin.model";
@Injectable()
export class AdminService {
 adminLogin:Admin;
  constructor(private http : Http) { }

  auth(adminLogin:Admin){
    const body = JSON.stringify(adminLogin);
    const headerOptions = new Headers({'Content-Type':'application/json'});
    const requestOptions = new RequestOptions({method: RequestMethod.Post, headers:headerOptions});
    return this.http.post('url',body,requestOptions).map((data:Response) => {
      return data.json();
    })
  }
  


}

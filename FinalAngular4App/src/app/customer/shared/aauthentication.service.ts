import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { CustomerLogin } from "../shared/customer-login";

@Injectable()
export class AauthenticationService {
    selectcustomerlogin:CustomerLogin;

  constructor(private http: HttpClient) { }

  login(CustomerId: string, CustomerPassword: string) {
    return this.http.post<any>('api/CustomerLogin', { username: CustomerId, password: CustomerPassword })
        .map(user => {
            // login successful if there's a jwt token in the response
            if (user && user.token) {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('currentUser', JSON.stringify(user));
            }

            return user;
        });
}


}

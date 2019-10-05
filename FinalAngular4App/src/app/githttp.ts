import { Component, OnInit,OnDestroy,Injectable } from '@angular/core';
import {Http, Response} from '@angular/http';
import {Observable} from 'rxjs/Observable';
import { Subscription } from 'rxjs/Subscription';
import 'rxjs/Rx';
import { User } from './git';
 
@Injectable()
export class GithubAPIService {
  loading:boolean;

  //dependency Injection
  constructor(private http: Http) {  }

  getUsers(){
        this.loading = true;
       return this.http.request('https://api.github.com/users/')
                .map((res:Response)=> res.json());
  }

  getUser(name:string) {    
   return this.http.get('https://api.github.com/users/' + name)
               .map((res:Response)=> res.json());
  }
}



@Component({
  selector: 'git-httpuser',
  template: `<h2>Transflower</h2>
             <h3>Celebrate Life with knowledge fragrance</h3>
            <div *ngIf="found">Product is  available</div>        
                 <div>
                    <div *ngIf="user" class="alert alert-success">
                    <p> {{user.name}}</p> <p> {{user.location}}</p>
                    <p> {{user.blog}}</p> <p> {{user.company}}</p>
                </div> 
            <div>
            </div>`
})
export class GitHttpComponent implements OnInit {
  users:User[];
  user:any;
 

  public user_error:boolean=false;
  public found:boolean=false;

  constructor(private svc: GithubAPIService) { 
    this.svc.getUser("ravitambade").subscribe(
        data=>{this.user=data;
              console.log(this.user);
               this.found=true;},
        err=>{this.user_error=true;}
           )
  }
  
  ngOnInit() {
       this.svc.getUser("ravitambade").subscribe(
                                              data=>{this.user=data; this.found=true;},
                                              err=>{this.user_error=true;}
                                      )
  }
}

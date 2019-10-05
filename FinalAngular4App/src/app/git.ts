import { Component,Injectable, OnInit,ReflectiveInjector } from '@angular/core';
export class User  {  
   constructor(public name:string,public location:string,
               public company:string,public blog:string)  { }
   }
   
@Injectable()
export class GithubService {
  constructor() { }
  getUser(name:string):User
  {
    return new User(name,
                         name+"@transflwer.in","Transflower",
                        "http://wordpress.com/ravitambade");
  }
  getAllUsers():User[]
  {
    let  users=[
            new User("ravitambade","ravi.tambade@transflwer.in","Transflower","http://wordpress.com/ravitambade"),
            new User("rahulnavale","rahul.navale@transflwer.in","Transflower","http://wordpress.com/rahulnavale"),
            new User("omkarhinge","omkar.hinge@transflwer.in","Transflower","http://wordpress.com/omkarhinge"),
            new User("prachinene","prachi.nenee@transflwer.in","Transflower","http://wordpress.com/prachinene"),
        ];
        return users;
   }
}







@Component({
  selector: 'app-git',
  template: `<h2> Transflower Team</h2>
             <div *ngFor="let user of users">
             <p>{{user.name}}  | {{user.location}} | {{user.eamil}} | {{user.blog}}`
})
export class GitComponent implements OnInit {
  users:User[];
  constructor(private svc: GithubService) { 
        //const injector: any = ReflectiveInjector.resolveAndCreate([GithubService]);
        //this.svc = injector.get(GithubService);
  }          
  ngOnInit() {
     this.users= this.svc.getAllUsers();
  }
}
import { Component, OnInit } from '@angular/core';
import {Customer} from './entities/customer';

@Component({
    selector: 'register-customer',
    template: `<h1>Customer Registration Form</h1>
    <div>
        <form #customerForm="ngForm" (ngSubmit)="onSubmit(customerForm.value)">
            <table>
            <tr>
                <td><label>FirstName:</label></td>
              
                <input type="text" name="firstName" [ngModel]="model.firstName"
                        required minlength="3" maxlength="12" #firstName="ngModel">
                <small [hidden]="firstName.valid || (firstName.pristine && !customerForm.submitted)">
                                FirstName is required (minimum 3 characters).
                </small>
            </tr>
                
            <tr>
                <td><label>LastName:</label></td>
                <td><input type="text" name="lastName" [(ngModel)]="model.lastName"></td>
            </tr>
            <tr><td>
                  <label>Email:</label></td>
                  <input type="email" name="email" [ngModel]="model.email"
                           required pattern="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$"
                           #email="ngModel">
                  <small [hidden]="email.valid || (email.pristine && !customerForm.submitted)">
                        Email is Required and format should be <i>rahul@gmail.com</i>.
                  </small>
            </tr>
            <tr>
                <td> <label>BirthDate:</label></td>
                <td><input type="date" name="birthDate"  required 
                           [(ngModel)]="model.birthDate"></td>
            </tr>
            <tr>
                <td> <label>Age:</label></td>
                <td><input type="number" name="age"  required 
                           [(ngModel)]="model.age"></td>
            </tr>
            <tr>
                <td><label>PhoneNo:</label></td>
                <td><input type="text" name="phoneNo"  required [(ngModel)]="model.phoneNo"></td>
            </tr> 
             <tr>
                <td><label>Location:</label></td>
                <select id="location" required [(ngModel)]="model.location"
                        name="location" #location ="ngModel" >
                    <option *ngFor = "let loc of locations" [value]="loc">{{loc}}</option>
                </select>
                <div [hidden]="location.valid || location.pristine">
                        Location is Required
                </div>
            </tr> 
            <tr>
                <td><label>Membership:</label></td>
                <div *ngFor="let memberShip of memberShips">
                    <label>
                        <input type="radio" name="memberShip"  required="model.memberShip" 
                               [value]="memberShip.value"> {{memberShip.display}}
                    </label>
                </div>
            </tr>
            <tr>
                <td><label>Status</label></td>
                <input type="checkbox" name="IsRegistered" [(ngModel)]="model.isRegistered"
                       value='false'>IsRegistered<br>
            </tr>
            <tr>
                <td><label>Source Of Information:</label></td>
                <select multiple name="social" [(ngModel)]="model.socialStatus">
                    <option *ngFor="let socialData of social" [value]="socialData.value">
                        {{socialData.display}}
                </select>
            </tr>    
            <tr>
              <td><button type="submit" [disabled] = "!customerForm.form.valid">
                          Add Customer</button> 
              </td>
              <td><button type="submit">Reset</button> </td>
            </tr>
      </table>
    </form>
    </div> `,
  })
  export class RegistrationComponent  {
  
   submitted = false;
   locations = ['Pune','Mumbai','Delhi','Bangalore','Nashik','Chennai'];
   memberShips = [
                  {value:'G',display:'Gold'},
                  {value:'S',display:'Silver'},
                  {value:'P',display:'Platinum'}
   ];
  
   social =[
              {value:'T',display:'Twitter'},
              {value:'F',display:'Facebook'},
              {value:'B',display:'Blog'}
   ];
  
  
   socialStatus = ['T', 'B'];
 
 
   model=new Customer('Ravi','Tambade','ravi.tambade@transflower.in',9881735801,28,
                      new Date(1975,18,8),this.locations[0],
                      this.memberShips[1].value,
                      false,this.socialStatus);
    constructor() {  }
  
  
   onSubmit(form: any): void {
        this.submitted=true;
        console.log('you submitted value:', form);
   }
  
   showCustomer(form:any){
          return form && form.controls['firstName'] && form.controls['firstName'].value;
    }
  
    showFormControls(form:any){
      return form && form.controls['firstName'] && form.controls['firstName'].value;
    }
  }

import { Component, OnInit,OnDestroy,Injectable } from '@angular/core';
import {Http, Response} from '@angular/http';
import {Observable} from 'rxjs/Observable';
import { Subscription } from 'rxjs/Subscription';
import 'rxjs/Rx';
 
  
@Injectable()
export class ProductAPIService {
  loading:boolean;

  //dependency Injection
  constructor(private http: Http) {  }

  getProducts(){
        this.loading = true;
        let url:string="http://localhost:58918/api/products/";
        return this.http.get(url)
        .map((res:Response)=> res.json());
  }

  getProduct(id:number) { 
      
    let url:string="http://localhost:58918/api/products/"+id;
    return this.http.get(url)
    .map((res:Response)=> res.json());
     

  }
}




@Component({
    selector: 'git-httpproduct',
    template: `<h2>Transflower</h2>
               <h3>Celebrate Life with knowledge fragrance</h3>
              <div *ngIf="found">Product is  available</div>        
                
                  <div>
                  <div *ngIf="product" class="alert alert-success">
                  <p> Title: {{product.Title}}</p> <p>Description:  {{product.Description}}</p>
                  <p> UnitPrice: {{product.UnitPrice}}</p> <p>Quantity: {{product.Balance}}</p>
              </div>
              
              <div>
              <h3>Flower List</h3>
                  <ul>
                      <li *ngFor="let product of products">
                          <p> {{product.Title}} | {{product.UnitPrice|currency:USD}} | 
                              {{product.Balance}}  <p>
                      </li>
                  </ul> 
              </div>
              `
  })
  export class ProductHttpComponent implements OnInit {
  
    product:any;     //to show one flower
    products:any[];  //to show list of flowers
  
    public product_error:boolean=false;
    public found:boolean=false;
  
    constructor(private svc: ProductAPIService) { 
      this.svc.getProduct(19).subscribe(
          data=>{this.product=data;
                console.log(this.product);
                 this.found=true;},
          err=>{this.product_error=true;}
             )
    }
    
    ngOnInit() {
     
         this.svc.getProduct(19).subscribe(
                                                data=>{this.product=data; this.found=true;},
                                                err=>{this.product_error=true;}
                                        ) 
                                                   
          this.svc.getProducts().subscribe(
                                          data=>{this.products=data; this.found=true;},
                                          err=>{this.product_error=true;}
                                        ) 
    }
  }
 
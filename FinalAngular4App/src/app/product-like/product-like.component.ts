import { Component,Input,OnInit,OnDestroy } from '@angular/core';
@Component({
  selector: 'product-like',
  templateUrl: './product-like.component.html',
  styleUrls: ['./product-like.component.css']
})
export class ProductLikeComponent 
            implements OnInit ,OnDestroy{
  @Input() name:string;
  @Input() price:number;
  @Input() quantity:number;
  @Input() imageUrl:string;
  likes:number;

  constructor() { }
  ngOnInit() { console.log('onInit Invoked!');
               this.likes=12; }
  ngOnDestroy() {console.log('ngOnDestroy Invoked!');}
  order(){
    console.log("Your order has been submitted.");
    return false;
  }

  counterUpdate(event: any) {
    this.likes = event.count;
  }

  
}
import { Component, OnInit } from '@angular/core';
import {Product} from '../product';

@Component({
  selector: 'product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  names:string[];
  products:Product[];
  constructor() { }

  ngOnInit() {
    this.names=["Gerbera","Carnation", "Lily","Lotus"];
    
    this.products=[
      new Product("Gerbera","Celebration Flower",12,500),
      new Product("Carnation","Peace Flower",10,210),
      new Product("Lilly","Decorating Flower",8,320),
      new Product("Lotus","Worship Flower",23,300)
    ];
  }
}

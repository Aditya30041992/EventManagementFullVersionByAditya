import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'flower-detail',
  templateUrl: './tfl-flower-detail.component.html',
  styleUrls: ['./tfl-flower-detail.component.css']
})
export class TflFlowerDetailComponent implements OnInit {

  title:string;
  description:string;
  unitPrice:number;
  stocks:number;
  likes:number;
  
  constructor() { }

  ngOnInit() {
  }

}

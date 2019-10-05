//Typescript Syntax   

function greetText(name:string){
    return "Welcome to  Typscript" + name;
}

var myName:string="Ravi Tambade";
var age:number=42;
var isMarried:boolean=true;

export class Person{
    firstName:string;
    lastName:string;
    age:number;
    married:boolean;
}

export class Product{
    constructor( public name:string,
        public description:string,
        public price:number,
        public quantity:number){ }
}

export class Contact{
    locations:string[]=["Pune", "Mumbai","Chennai","Nashik"];

    contactNumers:Array<string>=["9881735801","9881735802"];
    
    constructor()
    {
        this.locations.forEach((location)=>console.log(location));
        this.contactNumers.forEach((contactNumber)=>console.log(contactNumber));
    }
    
    enumDemo(){
        enum Role{  Worker=3,
                    Manager,
                    Aadmin};
        var myRole:Role=Role.Worker;
        console.log(myRole);
    }

    dynamicTypeVariableDemo(){
        var something:any="As a string";
        something=25;
        something=[24,29,43];
    }

}

export class Report{
    data:Array<string>;
    constructor(data:Array<string>){
        this.data=data;
    }

    print(){
        this.data.forEach(function(line){console.log(line);});
       //this.data.forEach((line)=>console.log(line));
    }
}
//var r:Report=new Report(['First line','Second line']);
//r.run();


export class TabbledReport extends Report{
    headers:Array<string>;
    constructor(headers:string[], values:string[]){
        super(values);
        this.headers= headers;
    }

    print(){
        console.log(this.headers);
        super.print();
    }
}
//var headers:string[]=['Name'];
//var data:string[]=['Ravi Tambade', 'Rahul Navale','Omkar Hinge'];
//var r:Report = new TabbedReport(headers, data);
//r.print();


export module Drawing{
    export interface Shape{
        draw(context:string):void;
    }

    export class Point{
        private x:number;
        private y:number;

        constructor(x:number, y:number){
            this.x=x;
            this.y=y;
        }
    }

    export class Line implements Shape{
        private startPoint:Point;
        private endPoint:Point;

        constructor(stPt:Point,endPt:Point){
            this.startPoint=stPt;
            this.endPoint=endPt;
        }
        public draw(cotext:string){
            console.log("Drawing Line");
        }
    }

    export class Rectangle implements Shape{
         private startPoint:Point;
         private endPoint:Point;
     
         constructor(stPt:Point,endPt:Point){
             this.startPoint=stPt;
             this.endPoint=endPt;
         }
         public draw(cotext:string){
             console.log("Drawing Rectangle");
         }      
    }
}

//import {Darwing} from './shape';
//let l=new Drawing.Line();
//let rect=new Drawing.Rectangle();

//let s:Drawing.Shape=rect;
//s.draw("2D");  
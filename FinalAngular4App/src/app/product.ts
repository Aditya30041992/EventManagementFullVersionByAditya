//Typescript Syntax   


function greetText(name:string){
    return "Welcome to  Typscript" + name;
}
var age:number=36;
var married:boolean=true;









export class Product{
    constructor( public name:string,
        public description:string,
        public price:number,
        public quantity:number){ }
}














export class Person{
    firstName:string;
    lastName:string;
    age:number;
    married:boolean;
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



export class GenericsDemo{
    identityn(arg: number): number {
        return arg;
    }
    
    identitys(arg: string): string {
        return arg;
    }
    
    identitya(arg: any): any {
        return arg;
    }

    identityg<T>(arg: T): T {
        return arg;
    }
   // let output = identity<string>("myString");  
   // type of output will be 'string'
}


export class DestructringDemo{
    arrayDestructuring(): void{
        let input = [1, 2];
        let [first, second] = input;
        console.log(first); // outputs 1
        console.log(second); // outputs 2
    }

    arrayRemainingElements():void{
        let [first, ...rest] = [1, 2, 3, 4];
        console.log(first); // outputs 1
        console.log(rest); // outputs [ 2, 3, 4 ]
    }

    arrayTrailingElements():void{
        let [first] = [1, 2, 3, 4];
        console.log(first); // outputs 1
    }
}

export class SpreadDemo{
    simpleSpreadTest(){
        let first = [1, 2];
        let second = [3, 4];
        let bothPlus = [0, ...first, ...second, 5];
        console.log(bothPlus);
        //Spreading creates a shallow copy of first and second. 
        //They are not changed by the spread.
    }

    objectSpreadTest(){
        let defaults = { food: "spicy", price: "$$", ambiance: "noisy" };
        let search = { ...defaults, food: "rich" };
        console.log(search);      
    }
}
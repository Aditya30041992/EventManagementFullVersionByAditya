
export module Drawing {
    export interface Shape {   
         draw(context: string): void;   
    }

    export class Point{
        private _x: number;
        private _y: number;
        constructor(x:number,y:number) 
        {
            this._x=x;
            this._y=y;
        }
    }

    export class Line implements Shape {
    private _startPoint: Point;
    private _endPoint: Point;
        constructor() {
            this._startPoint = new Point(23,34);
            this._endPoint = new Point(100,200);
        }
    
        public draw(context:string) {
            console.log("Drawing Line");
        }
    }

    export class Rectangle implements Shape {
    private _startPoint: Point;
    private _endPoint: Point;
        constructor() {
            this._startPoint = new Point(23,34);
            this._endPoint = new Point(100,200);
        }
    
        public draw(context:string) {
            console.log("Drawing Rectangle");
        }
    }
}

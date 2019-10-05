export class Product1{
    id: number;
    title:string;
    brand:string;
    category:string;
    unitPrice:number;
    quantity:number;
    description:string;
    canSell:boolean;

    
    constructor(id:number,title: string,  brand: string, 
                description: string,category: string, unitPrice:number, 
                quantity:number,canSell:boolean) {
     this.id=id;
     this.title = title;
     this.brand=brand;
     this.description=description;
     this.category=category;
     this.unitPrice=unitPrice;
     this.quantity=quantity;
     this.canSell=canSell;
  }

   getTotalAmount():number{
     return this.quantity*this.unitPrice;
   }


}


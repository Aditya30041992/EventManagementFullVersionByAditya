export class Product{
    id: number;
    title:string;
    brand:string;
    category:string;
    unitPrice:number;
    quantity:number;
    description:string;
    
    constructor(id:number,title: string,  brand: string, 
                description: string,category: string, unitPrice:number, 
                quantity:number) {
     this.id=id;
     this.title = title;
     this.brand=brand;
     this.description=description;
     this.category=category;
     this.unitPrice=unitPrice;
     this.quantity=quantity;
  }

   getTotalAmount():number{
     return this.quantity*this.unitPrice;
   }


}


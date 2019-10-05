
export class Task  {
 
constructor(public  taskId:number,
            public  title:string,
            public  description:string,
            public  category:string,
            public  duration:number,
            public  startDate:Date,
            public  status:number,
            public  assignedTo:string,
            public  assignedBy:string)
            { }

}
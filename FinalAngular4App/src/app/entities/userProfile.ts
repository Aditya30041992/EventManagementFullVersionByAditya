
export class UserProfile  {

    constructor(public isLoggedin:boolean,
                public  userName:string,
                public  token:string,
                public  refreshToken:string){           
    }
}
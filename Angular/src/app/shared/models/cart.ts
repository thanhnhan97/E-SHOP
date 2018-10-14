
export interface Cart
{
    cartID : number;
    productID : number;
    dateCreate : Date;
    quantity : number;
    status : boolean;
    totalMoney : number;    
}

export interface TempCart extends Cart{
    Image: string;
    Name: string;
    Price: number;
}
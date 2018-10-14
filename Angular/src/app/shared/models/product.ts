import { ProductType } from "./producttype";

export interface Product {
    Carts:         any[];
    ProductType:   ProductType;
    ProductID:     number;
    Name:          string;
    Price:         number;
    Description:   string;
    Image:         null;
    ProductTypeID: number;
}

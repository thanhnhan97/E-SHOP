import { TempCart } from './../../../shared/models/cart';
import { Product } from './../../../shared/models/product';
import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { BaseService } from '../../../shared/base.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  listProduct$: Observable<Product[]>;
  listCart$ : Observable<TempCart[]>;
  constructor(
    private service: BaseService,
    private router : Router
  ) { }

  ngOnInit() { //<-- Initial GET API
    //Load Product
    //Get API with url 'http://localhost:4325/api/product' JSON and Ng service of Angular
    this.listProduct$ = this.service.getAll('/product') as Observable<Product[]>;
  }

  selectListCart()
  {
    let key = 'cart';
    const list = localStorage.getItem(key);
    if (list != '') {
      let itemsCart= of(
        JSON.parse(
          localStorage.getItem(key)
        )
      );
      return itemsCart;
    }
    return of([]);
  }

  viewDetail(id) {
    this.router.navigate([`/home/detail/${id}`]);
  }

  addCart(item: Product, quantity: number)
  {
     let tempCart:any = {};
    tempCart.productID =  item.ProductID;
    tempCart.Image =  item.Image;
    tempCart.Name =  item.Name;
    tempCart.quantity = quantity
    tempCart.cartID =  null;
    tempCart.dateCreate = null;
    tempCart.status = false;
    tempCart.totalMoney =  ( item.Price * quantity );
    tempCart.Price = item.Price;
    
    let list = this.selectListCart();
    if(list == undefined) //<-- check list item cart exist
    {
      //if exist
      list.subscribe(
        data => {
          let index = data.findIndex(x => x.productID === item.ProductID);
          if(index < -1)
          {
            //if item add didn't exist in list cart, then add new item
            data.push(tempCart); 

            //set session
            localStorage.setItem('cart', data.toString());
          }
          else{
              data[index].quantity += tempCart.quantity;
              data[index].totalMoney += tempCart.totalMoney;
              localStorage.setItem('cart', data.toString());
          }
        }
      )
    }else{
      //if don't exist list cart
      let list: TempCart[] = [];
      list.push(tempCart); 
      let json = JSON.stringify(list);   
      localStorage.setItem('cart', json);
      this.router.navigate(['/home/cart']);
    }
  }

}

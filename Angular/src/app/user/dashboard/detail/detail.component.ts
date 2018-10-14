import { Component, OnInit } from '@angular/core';
import { BaseService } from '../../../shared/base.service';
import { ActivatedRoute, RouterLinkActive, Router } from '@angular/router';
import { Location } from '@angular/common';
import { Observable, of } from 'rxjs';
import { Product } from '../../../shared/models/product';
import { TempCart } from '../../../shared/models/cart';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {

  product$ : Observable<Product>;
  listCart$ : Observable<TempCart[]>;
  constructor(
    private service: BaseService,
    private route : ActivatedRoute,
    private location: Location,
    private router : Router
  ) { }

  ngOnInit() {
    this.getByItem();
  }
  
  getByItem()
  {
    let id = this.route.snapshot.paramMap.get('id');
    this.product$ = this.service.getBy(`/product/${id}`) as Observable<Product>;
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

  addCart(item: Product, quantity: number)
  {
     let tempCart: any = {};
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

  goBack(){
    this.location.back();
  }

}

import { TempCart } from './../../../shared/models/cart';
import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  listCart$ : Observable<TempCart[]> = of([]);
  constructor() { }

  ngOnInit() {
    this.loadListCart()
  }

  loadListCart()
  {
    let list = localStorage.getItem('cart');
    if(list != '')
    {
      this.listCart$ = of(JSON.parse(list));
    }
    
  }

  removeItem(index: number)
  {
    this.listCart$.forEach(
      data => {
        data.splice(index,1);
        localStorage.setItem('cart', data.toString());
      }
    );
  }

}

import { Observable, of } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BaseService } from '../../shared/base.service';
import { map } from 'rxjs/operators';
import { Product } from '../../shared/models/product';
import { ProductType } from '../../shared/models/producttype';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  listProduct$: Observable<Product[]> = of([]);
  productForm: FormGroup;
  //of(): ép về kiểu observable   
  listProductType$: Observable<ProductType[]> = of([]);
  message: Observable<string>;
  constructor(
    private builder: FormBuilder,
    private service : BaseService
  ) {
    this.createProductForm();
  }

  ngOnInit() {
    this.loadProduct();
    this.loadProductType();
    console.log(this.listProductType$);
    
  }

  loadProduct()
  {
    this.service.getAll('/product').subscribe(
        data => {
          this.listProduct$ = of(data as Product[]);  
        }
    );
  }

  loadProductType()
  {
    this.service.getAll('/producttype').subscribe(
      data =>{
        this.listProductType$ = of(data as ProductType[]);
      }
    );    
  }

  createProductForm() {
    this.productForm = this.builder.group({
      ProductID: [],
      ProductTypeID: ['', Validators.required],
      Name: ['', [Validators.required]],
      Price: ['1'],
      Description: ['',[Validators.required]],
      Image: []
    });
  }

  addItem() {
    debugger
    this.service.add('/product', this.productForm.value).subscribe(
        data => {
          if(data)
          {
            this.listProduct$.forEach(
              x => {
                x.push(data as Product);
              }
            );
            this.showMessageBox('Add Item Success');
          }
          else{
            this.showMessageBox('Add Item Fail');
          }
        }
    );
  }

  deleteItem(item: Product, index: number) {
    this.service.delete(`/product/${item.ProductID}`).subscribe(
        data => {
          if(data)
          {
            this.listProduct$.forEach(
              data => {
                data.splice(index,1);
              }
            );
            this.showMessageBox('Delete Item Success');
          }
          else{
            this.showMessageBox('Delete Item Fail');
          }
        }
    );
  }

  updateItem() {
    debugger
    this.listProduct$.forEach(
      data => {
        let index = data.findIndex( x => x.ProductID === this.productForm.controls['ProductID'].value);
        data[index] = this.productForm.value;
      }
    );
    this.showMessageBox('Update success');
  }

  pathValueItem(item: Product) {
    this.productForm.patchValue({
      ProductID: item.ProductID,
      ProductTypeID: item.ProductTypeID,
      Name: item.Name,
      Price: item.Price,
      Description: item.Description,
      Image: item.Image
    });
  }

  uploadFile($event: FileList) {
    if ($event) {

      let url = `assets/imgs/${$event.item(0).name}`;
      this.productForm.patchValue({
        Image: url
      });
    }

  }

  selectChagneItem($event) {
    debugger
    this.productForm.patchValue({
      ProductTypeID: $event
    });
  }

  showMessageBox(message: string)
  {
    this.message = of(message);
    setTimeout(
      () => {
        this.message = of(null);
      }, 3000
    );
  }

}

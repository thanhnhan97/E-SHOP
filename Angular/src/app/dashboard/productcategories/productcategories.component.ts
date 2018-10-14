import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { BaseService } from '../../shared/base.service';
import { Observable, of } from 'rxjs';
import { map, switchMap, mergeMap } from "rxjs/operators";
import { ProductType } from '../../shared/models/producttype';

@Component({
  selector: 'app-productcategories',
  templateUrl: './productcategories.component.html',
  styleUrls: ['./productcategories.component.css']
})
export class ProductcategoriesComponent implements OnInit {

  productTypeForm: FormGroup;
  listProductType$: Observable<ProductType[]>;
  message: string = null;
  constructor(
    private baseService: BaseService,
    private formBuilder: FormBuilder
  ) {
    this.createProductTypeForm();
  }

  ngOnInit() {
    this.loadProductType();
    console.log(this.listProductType$);

  }

  loadProductType() {
    this.baseService.getAll('/producttype').subscribe(
      data => {
        this.listProductType$ = of(data as ProductType[]);
        console.log(this.listProductType$);

      }
    );
  }

  createProductTypeForm() {
    this.productTypeForm = this.formBuilder.group(
      {
        ProductTypeID: [''],
        Name: ['', [Validators.required]]
      }
    );
  }

  addItem() {
    this.baseService.add('/producttype', this.productTypeForm.value).subscribe(
      data => {
        if (data) {
          this.listProductType$.forEach(
            x => {
              x.push(data as ProductType);
            }
          );
          this.showMessageBox('Add Success');
        }
        else {
          this.showMessageBox('Add Fail');

        }
      }
    );
  }

  showMessageBox(message: string) {
    this.message = message;
    setTimeout(
      () => {
        this.message = null;
      }, 3000
    );
  }

  deleteItem(item: ProductType, index: any) {
   try {
    this.baseService.delete(`/producttype/${item.ProductTypeID}`).subscribe(
      data => {
        if (data) {
          this.listProductType$.forEach(
            data => {
              data.splice(index, 1);
            }
          );
          this.showMessageBox('Delete Success');
        }
        else {
          this.showMessageBox('Delete Fail');
        }
      }
    );
   } catch (error) {
    this.showMessageBox('Delete Fail');

   }
  }

  updateItem() {

    let key = this.productTypeForm.controls['ProductTypeID'].value;
    this.baseService.update(`/producttype/${key}`, this.productTypeForm.value).subscribe(
      data => {
        debugger
        if (data) {
          this.listProductType$.forEach(
            x => {
              let index = x.findIndex(x => x.ProductTypeID === key);
              x[index] = this.productTypeForm.value;
              this.productTypeForm.reset();
              this.showMessageBox('Update Success');
            }
          )
        }
        else {
          this.showMessageBox('Update Fail');
        }
      }
    );
  }

  pathValueItem(value: ProductType) {
    this.productTypeForm.patchValue(
      {
        ProductTypeID: value.ProductTypeID,
        Name: value.Name
      }
    );
  }

}

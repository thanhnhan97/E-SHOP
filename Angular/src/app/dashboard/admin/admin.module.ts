import { ProductcategoriesComponent } from './../productcategories/productcategories.component';
import { ProductsComponent } from './../products/products.component';
import { NgModule } from '@angular/core';
import { AdminComponent } from './admin.component';
import { AdminRoutingModule } from '../../shared/routes/admin.routing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NavbarAdminComponent } from '../navbar-admin/navbar-admin.component';
import { CommonModule } from '@angular/common';
import { BaseService } from '../../shared/base.service';

@NgModule({
  imports: [
    AdminRoutingModule,
    FormsModule,
    HttpClientModule,
    CommonModule,
    ReactiveFormsModule
  ],
  declarations: [
    AdminComponent,
    ProductsComponent,
    ProductcategoriesComponent,
    NavbarAdminComponent
  ],
  providers: [BaseService]
})
export class AdminModule { }

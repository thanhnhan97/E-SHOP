import { Routes, RouterModule } from '@angular/router';
import { ProductsComponent } from '../../dashboard/products/products.component';
import { ProductcategoriesComponent } from '../../dashboard/productcategories/productcategories.component';
import { AdminComponent } from '../../dashboard/admin/admin.component';
import { NgModule } from '@angular/core';

export const adminRoutes: Routes = [
    {
        path: 'product',
        component: ProductsComponent
    },
    {
        path: 'product-type',
        component: ProductcategoriesComponent
    },
    {
        path: '',
        component: AdminComponent
    }
];
@NgModule({
    imports: [ RouterModule.forChild(adminRoutes) ],
    exports: [ RouterModule ]
})
export class AdminRoutingModule{}

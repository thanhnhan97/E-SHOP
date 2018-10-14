import { CartComponent } from './../../user/dashboard/cart/cart.component';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from '../../user/dashboard/home/home.component';
import { DetailComponent } from '../../user/dashboard/detail/detail.component';
import { NgModule } from '@angular/core';

export const userRoute : Routes = [
    {
        path: '',
        component: HomeComponent
    },
    {
        path: 'cart',
        component: CartComponent
    },
    {
        path: 'detail/:id',
        component: DetailComponent
    }
];
@NgModule({
    imports: [ RouterModule.forChild(userRoute) ],
    exports: [ RouterModule ]
})
export class UserRoutingModule{}
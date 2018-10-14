import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { DetailComponent } from './detail/detail.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { userRoute, UserRoutingModule } from '../../shared/routes/user.routing';
import { CartComponent } from './cart/cart.component';
import { UserNavbarComponent } from './user-navbar/user-navbar.component';
import { UserFooterComponent } from './user-footer/user-footer.component';
import { BaseService } from '../../shared/base.service';

@NgModule({
  imports: [
    CommonModule,
    UserRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  declarations: [
    HomeComponent,
    DetailComponent,
    CartComponent,
    UserNavbarComponent,
    UserFooterComponent
  ],
  providers: [BaseService]
})
export class DashboardModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';
import { RouterModule,Routes}    from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AdminRoutes, TaskRoutes } from './route';
import {CustomerRoutes} from './route';
import {HomeRoutes} from './route';
import {ShowAll} from './route';

import {HttpModule} from '@angular/http';
import { AppComponent } from './app.component';
import { CustomerComponent } from './customer/customer.component';
import { CustomerRegisterComponent } from './customer/customer-register/customer-register.component';
import { CustomerLoginComponent } from './customer/customer-login/customer-login.component';
import { AdminComponent } from './admin/admin.component';
import {ToastrModule} from 'ngx-toastr';
import { AdminTaskComponent } from './admin-task/admin-task.component';
import { AddVenuesComponent } from './admin-task/add-venues/add-venues.component';
import { LocationStrategy, APP_BASE_HREF, HashLocationStrategy } from '@angular/common';
import { AddEquipmentComponent } from './admin-task/add-equipment/add-equipment.component';
import { AddLightComponent } from './admin-task/add-light/add-light.component';
import { AddFlowerComponent } from './admin-task/add-flower/add-flower.component';
import { AddFoodComponent } from './admin-task/add-food/add-food.component';

//Customer Dashboard
import { CustomerTaskComponent } from './customer-task/customer-task.component';
import { BookingVenueComponent } from './customer-task/booking-venue/booking-venue.component';
import { BookingEquipmentComponent } from './customer-task/booking-equipment/booking-equipment.component';
import { BookingLightingComponent } from './customer-task/booking-lighting/booking-lighting.component';
import { BookingFlowerComponent } from './customer-task/booking-flower/booking-flower.component';
import { BookingFoodComponent } from './customer-task/booking-food/booking-food.component';
import { ChangePasswordComponent } from './customer-task/change-password/change-password.component';
import { VenueService } from './admin-task/Shared/venue.service';
import { CustomerTaskService } from './customer-task/shared/customer-task.service';
import { CustomerService } from './customer/shared/customer.service';
import { HomeComponent } from './home/home.component';
import { AboutusComponent } from './home/aboutus/aboutus.component';
import { ContactusComponent } from './home/contactus/contactus.component';
import { HomepageComponent } from './home/homepage/homepage.component';
import { CustomerListComponent } from './customer/customer-list/customer-list.component';
import { ShowEquipmentComponent } from './admin-task/show-equipment/show-equipment.component';
import { ShowFlowerComponent } from './admin-task/show-flower/show-flower.component';
import { ShowFoodComponent } from './admin-task/show-food/show-food.component';
import { ShowLightComponent } from './admin-task/show-light/show-light.component';
import { ShowVenueComponent } from './admin-task/show-venue/show-venue.component';
import { EditVenueComponent } from './admin-task/edit-venue/edit-venue.component';
import { EditEquipmentComponent } from './admin-task/edit-equipment/edit-equipment.component';
import { EditFlowerComponent } from './admin-task/edit-flower/edit-flower.component';
import { EditFoodComponent } from './admin-task/edit-food/edit-food.component';
import { EditLightingComponent } from './admin-task/edit-lighting/edit-lighting.component';
import { AdminService } from './admin/shared/admin.service';
import { BookingRouteComponent } from './customer-task/booking-route/booking-route.component';
import { VenueListComponent } from './customer-task/booking-venue/venue-list/venue-list.component';
import { AauthenticationService } from './customer/shared/aauthentication.service';
import { HttpClientModule } from '@angular/common/http';
import { DisplayAllBookingsComponent } from './customer-task/display-all-bookings/display-all-bookings.component';
import { ShowBookingComponent } from './admin-task/show-booking/show-booking.component';

@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent,
    CustomerRegisterComponent,
    CustomerLoginComponent,
    AdminComponent,

    AdminTaskComponent,
    AddVenuesComponent,
    AddEquipmentComponent,
    AddLightComponent,
    AddFlowerComponent,
    AddFoodComponent,

    //Customer Modules
    CustomerTaskComponent,
    BookingVenueComponent,
    BookingEquipmentComponent,
    BookingLightingComponent,
    BookingFlowerComponent,
    BookingFoodComponent,
    ChangePasswordComponent,
    HomeComponent,
    AboutusComponent,
    ContactusComponent,
    HomepageComponent,
    CustomerListComponent,
    ShowEquipmentComponent,
    ShowFlowerComponent,
    ShowFoodComponent,
    ShowLightComponent,
    ShowVenueComponent,
    EditVenueComponent,
    EditEquipmentComponent,
    EditFlowerComponent,
    EditFoodComponent,
    EditLightingComponent,
    BookingRouteComponent,
    VenueListComponent,
    DisplayAllBookingsComponent,
    ShowBookingComponent,
    
  ],

  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    HttpClientModule,
    BrowserAnimationsModule,
 
    ToastrModule.forRoot(),
  RouterModule.forRoot(CustomerRoutes),
  RouterModule.forRoot(AdminRoutes),
  RouterModule.forRoot(HomeRoutes),
  RouterModule.forRoot(ShowAll),
  RouterModule.forRoot(TaskRoutes),
  ],
  
  providers: [
    {provide:APP_BASE_HREF,useValue:'/'},
    {provide:LocationStrategy,useClass:HashLocationStrategy},
    CustomerService,
    VenueService,
    CustomerTaskService,
    AdminService,
    AauthenticationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

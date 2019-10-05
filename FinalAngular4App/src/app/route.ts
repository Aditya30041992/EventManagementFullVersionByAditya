import { Routes } from '@angular/router';
import {AddVenuesComponent} from './admin-task/add-venues/add-venues.component';
import { AddEquipmentComponent } from './admin-task/add-equipment/add-equipment.component';
import { AddFlowerComponent } from './admin-task/add-flower/add-flower.component';
import { AddLightComponent } from './admin-task/add-light/add-light.component';
import { AddFoodComponent } from './admin-task/add-food/add-food.component';
import { BookingVenueComponent } from './customer-task/booking-venue/booking-venue.component';
import { BookingEquipmentComponent } from './customer-task/booking-equipment/booking-equipment.component';
import { BookingFlowerComponent } from './customer-task/booking-flower/booking-flower.component';
import { BookingLightingComponent } from './customer-task/booking-lighting/booking-lighting.component';
import { BookingFoodComponent } from './customer-task/booking-food/booking-food.component';
import { ChangePasswordComponent } from './customer-task/change-password/change-password.component';
import { AboutusComponent } from './home/aboutus/aboutus.component';
import { ContactusComponent } from './home/contactus/contactus.component';
import { AdminComponent } from './admin/admin.component';
import { CustomerRegisterComponent } from './customer/customer-register/customer-register.component';
import { CustomerLoginComponent } from './customer/customer-login/customer-login.component';
import { HomepageComponent } from './home/homepage/homepage.component';
import { ShowVenueComponent } from './admin-task/show-venue/show-venue.component';
import { ShowEquipmentComponent } from './admin-task/show-equipment/show-equipment.component';
import { ShowFlowerComponent } from './admin-task/show-flower/show-flower.component';
import { ShowFoodComponent } from './admin-task/show-food/show-food.component';
import { ShowLightComponent } from './admin-task/show-light/show-light.component';
import { CustomerTaskComponent } from './customer-task/customer-task.component';
import { AdminTaskComponent } from './admin-task/admin-task.component';
import { BookingRouteComponent } from './customer-task/booking-route/booking-route.component';
import { VenueListComponent } from './customer-task/booking-venue/venue-list/venue-list.component';
import { DisplayAllBookingsComponent } from './customer-task/display-all-bookings/display-all-bookings.component';
import { CustomerListComponent } from './customer/customer-list/customer-list.component';
import { ShowBookingComponent } from './admin-task/show-booking/show-booking.component';

export const AdminRoutes: Routes = [
    { path: '', redirectTo: '', pathMatch: 'full' }, 
    { path: 'add-venues', component: AddVenuesComponent },
    { path: 'add-equipment', component: AddEquipmentComponent },
    { path: 'add-flower', component: AddFlowerComponent },
    { path: 'add-light', component: AddLightComponent },
    { path: 'add-food', component: AddFoodComponent },
    { path: 'show-booking', component: ShowBookingComponent },
    { path: 'customer-list', component: CustomerListComponent }

    
];

export const TaskRoutes: Routes = [
     
    { path: 'customer-task', component: CustomerTaskComponent },
    { path: 'admin-task', component: AdminTaskComponent },
    { path: 'booking-route', component: BookingRouteComponent }

];
export const CustomerRoutes: Routes = [
    { path: 'venue-list', component: VenueListComponent },
    { path: 'show-booking-route', component: DisplayAllBookingsComponent },    
    { path: 'booking-venue', component: BookingVenueComponent },
    { path: 'booking-equipment', component: BookingEquipmentComponent },
    { path: 'booking-lighting', component: BookingLightingComponent },
    { path: 'booking-flower', component: BookingFlowerComponent },
    { path: 'booking-food', component: BookingFoodComponent },
    { path: 'change-password', component: ChangePasswordComponent }

];
    export const HomeRoutes: Routes = [
        { path: '', redirectTo: '', pathMatch: 'full' }, 
        { path: 'homepage', component: HomepageComponent },
        { path: 'aboutus', component: AboutusComponent },
        { path: 'contactus', component: ContactusComponent },
        { path: 'admin', component: AdminComponent},
        { path: 'customer-login', component: CustomerLoginComponent },
        { path: 'customer-register', component: CustomerRegisterComponent }
    
];

export const ShowAll: Routes = [
    { path: '', redirectTo: '', pathMatch: 'full' }, 
    { path: 'show-venue', component: ShowVenueComponent },
    { path: 'show-equipment', component: ShowEquipmentComponent },
    { path: 'show-flower', component: ShowFlowerComponent },
    { path: 'show-food', component: ShowFoodComponent},
    { path: 'show-light', component: ShowLightComponent }
];


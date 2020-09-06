import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { SignupComponent } from './Components/signup/signup.component';
import { ListProductComponent } from './Components/list-product/list-product.component';
import { LoginComponent } from './Components/login/login.component';
import { ListCategoryComponent } from './Components/list-category/list-category.component';
import { CartComponent } from './Components/cart/cart.component';
import { PaymentComponent } from './Components/payment/payment.component';
import { WarningComponent } from './Components/warning/warning.component';
import { ProductDetailComponent } from './Components/product-detail/product-detail.component';
import { FavouriteComponent } from './Components/favourite/favourite.component';
import { ContactComponent } from './Components/contact/contact.component';
import { AboutComponent } from './Components/about/about.component';
import { AuthService } from './Services/auth.service';
import { OrderHistoryComponent } from './Components/order-history/order-history.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'category/:category', component: ListCategoryComponent },
  { path: 'product/:type/:searchValue', component: ListProductComponent },
  { path: 'cart', component: CartComponent, canActivate: [AuthService]},
  { path: 'payment', component: PaymentComponent, canActivate: [AuthService]},
  { path: 'error', component: WarningComponent },
  { path: 'details/:productId', component: ProductDetailComponent },
  { path: 'favourite', component: FavouriteComponent, canActivate: [AuthService]},
  { path: 'about', component: AboutComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'orders', component: OrderHistoryComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }

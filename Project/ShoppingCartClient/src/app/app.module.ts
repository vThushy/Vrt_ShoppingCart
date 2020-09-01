import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HeaderComponent } from './Components/header/header.component';
import { NavComponent } from './Components/nav/nav.component';
import { SliderComponent } from './Components/slider/slider.component';
import { SocialComponent } from './Components/social/social.component';
import { ListProductComponent } from './Components/list-product/list-product.component';
import { HomeComponent } from './Components/home/home.component';
import { ProductRowComponent } from './Components/product-row/product-row.component';
import { SignupComponent } from './Components/signup/signup.component';
import { CategoryComponent } from './Components/category/category.component';
import { UsersService } from './Services/users.service';
import { LoginComponent } from './Components/login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { ListCategoryComponent } from './Components/list-category/list-category.component';
import { FooterComponent } from './Components/footer/footer.component';
import { FilterComponent } from './Components/filter/filter.component';
import { LoaderComponent } from './Components/loader/loader.component';
import { CartComponent } from './Components/cart/cart.component';
import { PaymentComponent } from './Components/payment/payment.component';
import { WarningComponent } from './Components/warning/warning.component';
import { ProductDetailComponent } from './Components/product-detail/product-detail.component';
import { OrderHistoryComponent } from './Components/order-history/order-history.component';
import { FavouriteComponent } from './Components/favourite/favourite.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    NavComponent,
    SliderComponent,
    SocialComponent,
    FooterComponent,
    ListProductComponent,
    HomeComponent,
    ProductRowComponent,
    CategoryComponent,
    SignupComponent,
    LoginComponent,
    ListCategoryComponent,
    FilterComponent,
    LoaderComponent,
    CartComponent,
    PaymentComponent,
    WarningComponent,
    ProductDetailComponent,
    OrderHistoryComponent,
    FavouriteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule
     
  ],
  providers: [UsersService],
  bootstrap: [AppComponent]
})
export class AppModule { }

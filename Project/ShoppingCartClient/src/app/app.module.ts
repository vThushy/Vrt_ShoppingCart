import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HeaderComponent } from './Components/header/header.component';
import { NavComponent } from './Components/nav/nav.component';
import { SliderComponent } from './Components/slider/slider.component';
import { SocialComponent } from './Components/social/social.component';
import { FooterComponent } from './Components/footer/footer.component';
import { ListProductComponent } from './Components/list-product/list-product.component';
import { HomeComponent } from './Components/home/home.component';
import { ProductRowComponent } from './Components/product-row/product-row.component';
import { SignupComponent } from './Components/signup/signup.component';
import { CategoryComponent } from './Components/category/category.component';
import { UsersService } from './Services/users.service';
import { LoginComponent } from './Components/login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { ListCategoryComponent } from './Components/list-category/list-category.component';
import { FilterComponent } from './filter/filter.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoaderComponent } from './loader/loader.component';
//import {MatProgressSpinnerModule} from '@angular/material';
// import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';

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
    LoaderComponent
    // MatProgressSpinnerModule
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    NgbModule
  ],
  providers: [UsersService],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { NavComponent } from './nav/nav.component';
import { SliderComponent } from './slider/slider.component';
import { SellerComponent } from './seller/seller.component';
import { SocialComponent } from './social/social.component';
import { FooterComponent } from './footer/footer.component';
import { ListProductComponent } from './list-product/list-product.component';
import { HomeComponent } from './home/home.component';
import { ProductRowComponent } from './product-row/product-row.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    NavComponent,
    SliderComponent,
    SellerComponent,
    SocialComponent,
    FooterComponent,
    ListProductComponent,
    HomeComponent,
    ProductRowComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

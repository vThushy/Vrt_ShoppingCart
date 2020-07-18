import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { SignupComponent } from './Components/signup/signup.component';
import { CategoryComponent } from './Components/category/category.component';
import { ListProductComponent } from './Components/list-product/list-product.component';
import { LoginComponent } from './Components/login/login.component';
import { ListCategoryComponent } from './Components/list-category/list-category.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'category/:category', component: ListCategoryComponent },
  { path: 'product/:searchValue', component: ListProductComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListProductComponent } from './list-product/list-product.component';
import { HomeComponent } from './home/home.component';
import { UserComponent } from './user/user.component';
import { CategoryComponent } from './category/category.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: UserComponent },
  { path: 'category/:category', component: CategoryComponent },
  { path: 'list/:category', component: ListProductComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }

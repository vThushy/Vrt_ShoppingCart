import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListProductComponent } from './list-product/list-product.component';
import { HomeComponent } from './home/home.component';


const routes: Routes = [
  { path: 'list', component: ListProductComponent },
  { path: '', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

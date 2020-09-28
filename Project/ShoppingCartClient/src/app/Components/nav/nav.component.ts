import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  searchValue: string;
  productSearchPath = "/product/by-category/";
  productFilterPath = "/product/by-filter/";


  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  searchProducts() {
    this.router.navigate([this.productFilterPath, this.searchValue]);
  }
}

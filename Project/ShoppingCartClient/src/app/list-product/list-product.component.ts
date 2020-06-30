import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrls: ['./list-product.component.css']
})
export class ListProductComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
  ) {}

  ngOnInit(): void {
    // this.route.queryParams.subscribe(params => {
    //   this.name = params['name'];
    // });
  }

}

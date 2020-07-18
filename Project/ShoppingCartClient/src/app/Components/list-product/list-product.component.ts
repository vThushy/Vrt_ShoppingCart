import { Component, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrls: ['./list-product.component.css']
})
export class ListProductComponent implements OnChanges {

  searchValue: string;
  noOfResults: number;
  noOfPages= 1;


  constructor(
    private route: ActivatedRoute,
  ) {}

  ngOnChanges(changes: SimpleChanges): void {
    this.searchValue = this.route.snapshot.paramMap.get("searchValue");   
    this.noOfPages = this.noOfResults / 9;
  }
 


}

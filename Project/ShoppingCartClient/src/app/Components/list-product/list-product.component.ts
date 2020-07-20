import { Component, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { ProductsService } from 'src/app/Services/products.service';
import { ExceptionHandlerService } from 'src/app/Util/exception-handler.service';

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrls: ['./list-product.component.css']
})
export class ListProductComponent implements OnChanges {

  searchValue: string;
  noOfResults: number;
  noOfPages = 1;

  constructor(
    private route: ActivatedRoute,
    private productService: ProductsService,
    private exceptionHandlerService: ExceptionHandlerService
  ) {
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.searchValue = this.route.snapshot.paramMap.get("searchValue");
    if (this.noOfResults > 0) {
      this.noOfPages = this.noOfResults / 9;
    } else {
      this.noOfResults = 0;
    }

    var listProduct = this.productService.getAllProducts().subscribe(
      result => {
        console.log(result);
      },
      error => {
        this.exceptionHandlerService.handleError(error);
      });
  }

}

import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-list-category',
  templateUrl: './list-category.component.html',
  styleUrls: ['./list-category.component.css']
})

export class ListCategoryComponent implements OnInit {
  heading:string;
  categories: string[][];
   
  constructor(
    private  route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.heading = this.route.snapshot.paramMap.get("category");
    if(this.heading == "women")
    {
      this.categories = this.womenCategories
    }
  }

  urlCategory = "/product";
  womenCategories = [
    ['TRADITIONAL WEAR', 'women-traditional', 'assets/images/cat_women_traditional.jpg'],
    ['CASUAL WEAR', 'women-casual', 'assets/images/cat_women_casual.jpg'],
    ['FORMAL WEAR', 'women-formal', 'assets/images/cat_women_formal.jpg'],
    ['FOOT WEAR', 'womens-foot', 'assets/images/cat_women_foot.jpg'],
    ['ACCESSORIES', 'women-accessories', 'assets/images/cat_accessories.jpg']];
}

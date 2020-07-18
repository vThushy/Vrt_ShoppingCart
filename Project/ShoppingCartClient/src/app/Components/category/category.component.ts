import { Component, OnInit, OnChanges, Input, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnChanges {

  categories: string[][];
  urlCategory: string;

  @Input() InputUrlCategory: string;
  @Input() InputCategories: string[][];

  constructor() { }

  ngOnChanges(changes: SimpleChanges): void {
    this.urlCategory = this.InputUrlCategory;
    this.categories = this.InputCategories;
  }
}

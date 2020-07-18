import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-product-row',
  templateUrl: './product-row.component.html',
  styleUrls: ['./product-row.component.css']
})
export class ProductRowComponent implements OnChanges {
  heading: string;
  @Input() viewTitle: string;
  @Input() searchCriteria: String;

  constructor() {
    this.heading = this.viewTitle;
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.heading = this.viewTitle;
  
  }
}

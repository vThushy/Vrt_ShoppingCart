import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  cardTitle: string;
  mainCategories: string[][];
  urlCategory: string;
 
  constructor() { }

  ngOnInit(): void {
    this.urlCategory = "/category";
    this.cardTitle = 'NEW COLLECTION';
    this.mainCategories = [
      ['SHOP WOMENs', 'women', 'assets/images/cat_women.jpg'],
      ['SHOP MENs', 'men', 'assets/images/cat_men.jpg'],
      ['SHOP KIDs', '/list/kids', 'assets/images/cat_kids.jpg'],
      ['SHOP LIFESTYLE', '/list/lifestyle', 'assets/images/cat_lifestyle.jpg'],
      ['SHOP GIFTs', '/list/gift', 'assets/images/cat_gifts.jpg']];
  }

}

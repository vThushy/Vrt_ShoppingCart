import { Component, OnInit } from '@angular/core';
import { imagePath } from 'src/app/Util/paths';

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.css']
})
export class LoaderComponent implements OnInit {
  logoImagePath = imagePath.home_logo;

  constructor() { }

  ngOnInit(): void {
  }

}

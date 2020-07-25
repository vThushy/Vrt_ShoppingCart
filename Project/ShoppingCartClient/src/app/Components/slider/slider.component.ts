import { Component, OnInit } from '@angular/core';
import { imagePath } from 'src/app/Util/paths';

@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.css']
})
export class SliderComponent implements OnInit {
  slider_women = imagePath.slider_women;
  slider_men = imagePath.slider_men;
  slider_kid = imagePath.slider_kid;

  constructor() { }

  ngOnInit(): void {
  }

}

import { Component, OnInit } from '@angular/core';
import { storeLocatoion, policyAgreement } from 'src/app/Util/config';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
  storeLocationUrl = storeLocatoion;
  policyUrl = policyAgreement;

  constructor() { 
  }

  ngOnInit(): void {
  }

}

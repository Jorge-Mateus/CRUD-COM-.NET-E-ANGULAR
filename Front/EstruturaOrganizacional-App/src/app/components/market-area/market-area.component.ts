import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-market-area',
  templateUrl: './market-area.component.html',
  styleUrls: ['./market-area.component.scss']
})
export class MarketAreaComponent implements OnInit {

  constructor() { }
  public form: FormGroup;

  ngOnInit(): void {
  }

}

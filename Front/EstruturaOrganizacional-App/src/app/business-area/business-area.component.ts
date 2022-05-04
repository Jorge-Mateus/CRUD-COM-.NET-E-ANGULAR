import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-business-area',
  templateUrl: './business-area.component.html',
  styleUrls: ['./business-area.component.scss']
})
export class BusinessAreaComponent implements OnInit {


  public businessareas: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getBusinessArea();
  }

  public getBusinessArea(): void {
    this.http.get('https://localhost:5001/api/BusinessAreas').subscribe(
      Response => this.businessareas = Response,
      error => console.log(error)
    );
  }

}

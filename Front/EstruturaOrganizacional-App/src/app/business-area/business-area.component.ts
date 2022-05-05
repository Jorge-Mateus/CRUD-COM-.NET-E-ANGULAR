import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-business-area',
  templateUrl: './business-area.component.html',
  styleUrls: ['./business-area.component.scss']
})
export class BusinessAreaComponent implements OnInit {


  public businessareas: any = [];
  public businessareasfiltrados: any = [];
  private _filtroLista: string = '';

  public get filtroLista() {
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.businessareasfiltrados = this.filtroLista ? this.filtrarUnidades(this.filtroLista) : this.businessareas;
  }

  filtrarUnidades(filtrarPor: string): any{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.businessareas.filter(
      (businessarea: any) => businessarea.sigla.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      businessarea.codReduzido.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getBusinessArea();
  }

  public getBusinessArea(): void {
    this.http.get('https://localhost:5001/api/BusinessAreas').subscribe(
      Response => {
        this.businessareas = Response;
        this.businessareasfiltrados = this.businessareas;
      },
      error => console.log(error)
    );
  }

}

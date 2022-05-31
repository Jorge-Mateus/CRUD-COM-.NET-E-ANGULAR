import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OperatingUnit } from '@app/model/OperatingUnit';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OperitingUnitsService {

  baseUrl = 'https://localhost:5001/api/OperatingUnit';

constructor(private http: HttpClient) { }



public getOperatingUnit(): Observable<OperatingUnit[]> {
  return this.http.get<OperatingUnit[]>(this.baseUrl);
}

public getOperatingUnitySigla(sigla: string): Observable<OperatingUnit[]> {
  return this.http.get<OperatingUnit[]>(`${this.baseUrl}/${sigla}/sigla`);
}

public getOperatingUnitById(id: number): Observable<OperatingUnit> {
  return this.http.get<OperatingUnit>(`${this.baseUrl}/${id}`);
}

public post(operating: OperatingUnit): Observable<OperatingUnit> {
  return this.http.post<OperatingUnit>(this.baseUrl, operating);
}

public put(operating: OperatingUnit): Observable<OperatingUnit> {
  return this.http.put<OperatingUnit>(`${this.baseUrl}/${operating.id}`, operating);
}

public deleteOperatingUnits(id: number): Observable<any> {
  return this.http.delete<any>(`${this.baseUrl}/${id}`);
}


}

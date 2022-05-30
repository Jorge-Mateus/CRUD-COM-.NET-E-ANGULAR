import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BusinessArea } from '../model/BusinessArea';

@Injectable({
  providedIn: 'root'
})
export class BunissesAreaService {

  baseUrl = 'https://localhost:5001/api/BusinessAreas';

constructor(private http: HttpClient) { }

public getBunissesArea(): Observable<BusinessArea[]> {
  return this.http.get<BusinessArea[]>(this.baseUrl);
}

public getBunissesAreaBySigla(sigla: string): Observable<BusinessArea[]> {
  return this.http.get<BusinessArea[]>(`${this.baseUrl}/${sigla}/sigla`);
}

public getBunissesAreaById(id: number): Observable<BusinessArea> {
  return this.http.get<BusinessArea>(`${this.baseUrl}/${id}`);
}

public post(businessArea: BusinessArea): Observable<BusinessArea> {
  return this.http.post<BusinessArea>(this.baseUrl, businessArea);
}

public put(businessArea: BusinessArea): Observable<BusinessArea> {
  return this.http.put<BusinessArea>(`${this.baseUrl}/${businessArea.id}`, businessArea);
}

public deleteBunisses(id: number): Observable<any> {
  return this.http.delete<any>(`${this.baseUrl}/${id}`);
}

}

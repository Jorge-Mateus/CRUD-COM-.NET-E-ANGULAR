import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BusinessArea } from '../model/BusinessArea';

@Injectable({
  providedIn: 'root'
})
export class BunissesAreaService {

  baseUrl = 'https://localhost:5001/api/BusinessAreas'


constructor(private http: HttpClient) { }

getBunissesArea(): Observable<BusinessArea[]> {
  return this.http.get<BusinessArea[]>(this.baseUrl);
}

getBunissesAreaBySigla(sigla: string): Observable<BusinessArea[]> {
  return this.http.get<BusinessArea[]>(`${this.baseUrl}/${sigla}/sigla`);
}

getBunissesAreaById(id: number): Observable<BusinessArea> {
  return this.http.get<BusinessArea>(`${this.baseUrl}/${id}`);
}

}

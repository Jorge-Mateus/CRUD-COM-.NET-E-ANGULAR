import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OrganationalStructure } from '@app/model/OrganationalStructure';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrganizationStructureService {

baseUrl = 'https://localhost:5001/api/OrganizationalStructure';

constructor(private http: HttpClient) { }

public getOrganationalStructure(): Observable<OrganationalStructure[]> {
  return this.http.get<OrganationalStructure[]>(this.baseUrl);
}

public getOrganationalStructureBySigla(sigla: string): Observable<OrganationalStructure[]> {
  return this.http.get<OrganationalStructure[]>(`${this.baseUrl}/${sigla}/sigla`);
}

public getOrganationalStructureById(id: number): Observable<OrganationalStructure> {
  return this.http.get<OrganationalStructure>(`${this.baseUrl}/${id}`);
}

public post(organizacao: OrganationalStructure): Observable<OrganationalStructure> {
  return this.http.post<OrganationalStructure>(this.baseUrl, organizacao);
}

public put(organizacao: OrganationalStructure): Observable<OrganationalStructure> {
  return this.http.put<OrganationalStructure>(`${this.baseUrl}/${organizacao.id}`, organizacao);
}

public deleteBunisses(id: number): Observable<any> {
  return this.http.delete<any>(`${this.baseUrl}/${id}`);
}

}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TchnologicalArea } from '@app/model/TchnologicalArea';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TechnologicalAreaService {

  baseUrl = 'https://localhost:5001/api/TechnologicalArea';
constructor(private http: HttpClient) { }

public GetTechnologicalArea(): Observable<TchnologicalArea[]> {
  return this.http.get<TchnologicalArea[]>(this.baseUrl);
}

public GetTechnologicalAreaByDescricao(sigla: string): Observable<TchnologicalArea[]> {
  return this.http.get<TchnologicalArea[]>(`${this.baseUrl}/${sigla}/sigla`);
}

public GetTechnologicalAreaById(id: number): Observable<TchnologicalArea> {
  return this.http.get<TchnologicalArea>(`${this.baseUrl}/${id}`);
}

public post(technological: TchnologicalArea): Observable<TchnologicalArea> {
  return this.http.post<TchnologicalArea>(this.baseUrl, technological);
}

public put(technological: TchnologicalArea): Observable<TchnologicalArea> {
  return this.http.put<TchnologicalArea>(`${this.baseUrl}/${technological.id}`, technological);
}

public deleteTchnological(id: number): Observable<any> {
  return this.http.delete<any>(`${this.baseUrl}/${id}`);
}

}

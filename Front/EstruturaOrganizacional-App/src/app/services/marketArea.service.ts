import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MarketArea } from '@app/model/MarketArea';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MarketAreaService {

  baseUrl = 'https://localhost:5001/api/MarketArea';

  constructor(private http: HttpClient) { }

  public getMarketArea(): Observable<MarketArea[]> {
    return this.http.get<MarketArea[]>(this.baseUrl);
  }

  public getMarketAreaBySigla(sigla: string): Observable<MarketArea[]> {
    return this.http.get<MarketArea[]>(`${this.baseUrl}/${sigla}/sigla`);
  }

  public getMarketAreaById(id: number): Observable<MarketArea> {
    return this.http.get<MarketArea>(`${this.baseUrl}/${id}`);
  }

  public post(marketArea: MarketArea): Observable<MarketArea> {
    return this.http.post<MarketArea>(this.baseUrl, marketArea);
  }

  public put(marketArea: MarketArea): Observable<MarketArea> {
    return this.http.put<MarketArea>(`${this.baseUrl}/${marketArea.id}`, marketArea);
  }

  public deleteMarket(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/${id}`);
  }

}

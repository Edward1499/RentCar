import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class FuelService {

  private baseUrl: string = environment.apiUrl;

  private fuels: BehaviorSubject<[]> = new BehaviorSubject([]);

  public get getAll() : BehaviorSubject<[]> {
    if (!this.fuels.value.length) {
      this.setFuels();
    }
    return this.fuels;
} 

  constructor(private http: HttpClient) { }

  get(id: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/fuels/${id}`);
  }

  getAllActives(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/fuels/GetAllActive`);
  }

  add(request: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/fuels`, request);
  }

  update(id: number, request: any): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/fuels/${id}`, request);
  }

  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/fuels/${id}`);
  }

  setFuels() {
    return this.http.get<any>(`${this.baseUrl}/fuels`)
      .pipe(
        map(data => {
          this.fuels.next(data);
        }),
      ).subscribe();
  }
}

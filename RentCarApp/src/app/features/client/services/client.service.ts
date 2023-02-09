import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  private baseUrl: string = environment.apiUrl;

  private clients: BehaviorSubject<[]> = new BehaviorSubject([]);

  public get getAll() : BehaviorSubject<[]> {
    if (!this.clients.value.length) {
      this.setClients();
    }
    return this.clients;
  } 

  constructor(private http: HttpClient) { }

  get(id: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/clients/${id}`);
  }

  getAllList(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/clients`);
  }

  isValidPersonalNumber(personalNumber: string): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/clients/validate-number/${personalNumber}`);
  }

  getAllActives(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/clients/GetAllActive`);
  }

  add(request: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/clients`, request);
  }

  update(id: number, request: any): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/clients/${id}`, request);
  }

  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/clients/${id}`);
  }

  setClients() {
    return this.http.get<any>(`${this.baseUrl}/clients`)
      .pipe(
        map(data => {
          this.clients.next(data);
        }),
      ).subscribe();
  }
}

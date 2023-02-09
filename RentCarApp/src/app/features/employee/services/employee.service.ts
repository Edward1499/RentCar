import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private baseUrl: string = environment.apiUrl;

  private employees: BehaviorSubject<[]> = new BehaviorSubject([]);

  public get getAll() : BehaviorSubject<[]> {
    if (!this.employees.value.length) {
      this.setEmployees();
    }
    return this.employees;
  } 

  constructor(private http: HttpClient) { }

  get(id: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/employees/${id}`);
  }

  getAllList(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/employees`);
  }

  getAllActives(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/employees/GetAllActive`);
  }

  add(request: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/employees`, request);
  }

  update(id: number, request: any): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/employees/${id}`, request);
  }

  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/employees/${id}`);
  }

  setEmployees() {
    return this.http.get<any>(`${this.baseUrl}/employees`)
      .pipe(
        map(data => {
          this.employees.next(data);
        }),
      ).subscribe();
  }
}

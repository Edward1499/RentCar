import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class BrandService {

  private baseUrl: string = environment.apiUrl;

  private brands: BehaviorSubject<[]> = new BehaviorSubject([]);

  public get getAll() : BehaviorSubject<[]> {
    if (!this.brands.value.length) {
      this.setBrands();
    }
    return this.brands;
  } 

  constructor(private http: HttpClient) { }

  get(id: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/brands/${id}`);
  }

  getAllList(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/brands`);
  }

  getAllActives(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/brands/GetAllActive`);
  }

  add(request: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/brands`, request);
  }

  update(id: number, request: any): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/brands/${id}`, request);
  }

  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/brands/${id}`);
  }

  setBrands() {
    return this.http.get<any>(`${this.baseUrl}/brands`)
      .pipe(
        map(data => {
          this.brands.next(data);
        }),
      ).subscribe();
  }
}

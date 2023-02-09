import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ModelService {

  private baseUrl: string = environment.apiUrl;

  private models: BehaviorSubject<[]> = new BehaviorSubject([]);

  public get getAll() : BehaviorSubject<[]> {
    if (!this.models.value.length) {
      this.setModels();
    }
    return this.models;
} 

  constructor(private http: HttpClient) { }

  get(id: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/models/${id}`);
  }

  getByBrandId(brandId: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/models/${brandId}/GetByBrandId`);
  }

  add(request: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/models`, request);
  }

  update(id: number, request: any): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/models/${id}`, request);
  }

  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/models/${id}`);
  }

  setModels() {
    return this.http.get<any>(`${this.baseUrl}/models`)
      .pipe(
        map(data => {
          this.models.next(data);
        }),
      ).subscribe();
  }
}

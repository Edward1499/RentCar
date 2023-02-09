import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class VehicleTypeService {

  private baseUrl: string = environment.apiUrl;

  private vehicleTypes: BehaviorSubject<[]> = new BehaviorSubject([]);

  public get getAll() : BehaviorSubject<[]> {
    if (!this.vehicleTypes.value.length) {
      this.setVehicleTypes();
    }
    return this.vehicleTypes;
} 

  constructor(private http: HttpClient) { }

  get(id: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/VehicleTypes/${id}`);
  }

  getAllActives(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/VehicleTypes/GetAllActive`);
  }

  add(request: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/VehicleTypes`, request);
  }

  update(id: number, request: any): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/VehicleTypes/${id}`, request);
  }

  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/VehicleTypes/${id}`);
  }

  setVehicleTypes() {
    return this.http.get<any>(`${this.baseUrl}/VehicleTypes`)
      .pipe(
        map(data => {
          this.vehicleTypes.next(data);
        }),
      ).subscribe();
  }
}

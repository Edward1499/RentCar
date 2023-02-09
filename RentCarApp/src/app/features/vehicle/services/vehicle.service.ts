import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  private baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  get(id: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/vehicles/${id}`);
  }

  getAll(request: any): Observable<any> {
    const params = `PageSize=${request.pageSize}&PageIndex=${request.pageIndex}&FuelId=${request.fuelId}&VehicleTypeId=${request.vehicleTypeId}&BrandId=${request.brandId}&ModelId=${request.modelId}&IsActive=${request.isActive}`;
    return this.http.get<any>(`${this.baseUrl}/vehicles?${params}`);
  }

  getAllActives(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/vehicles/GetAllActive`);
  }

  add(request: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/vehicles`, request);
  }

  addTransaction(request: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/transactions`, request);
  }

  completeTransaction(vehicleId: number): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/transactions/${vehicleId}`, {});
  }

  update(id: number, request: any): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/vehicles/${id}`, request);
  }

  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/vehicles/${id}`);
  }
}

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  private baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  generate(request: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/reports`, request, {responseType: 'text'});
  }

}

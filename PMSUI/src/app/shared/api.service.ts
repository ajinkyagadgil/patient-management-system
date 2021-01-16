import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppconfigService } from './appconfig.service';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient,
    private config: AppconfigService) { }

  get<T>(action: string, options?: Object): Observable<T> {
    return this.http.get<T>(this.getAPIEndpoint(action), options);
  }

  post<T>(action: string, body?: any, options?: Object): Observable<T> {
    return this.http.post<T>(this.getAPIEndpoint(action), body, options);
  }

  getAPIEndpoint(action: string) {
    return `${this.config.apiBaseUrl}api/${action}`; 
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {map, catchError} from 'rxjs/operators'


@Injectable()
export class AppconfigService {
  private appConfig: any;
  constructor(private http: HttpClient) { }

  loadAppConfig() {
    return this.http.get('assets/config.json')
      .toPromise()
      .then(data => {
        this.appConfig = data;
      });
  }

  get apiBaseUrl() {
    if (!this.appConfig) {
      throw Error('Config file not loaded!');
    }

    return this.appConfig.apiBaseUrl;
  }
}

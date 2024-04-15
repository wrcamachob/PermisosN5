import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from '../environments/environment';
import { ServiceParent } from '../parents/service-parent';

@Injectable({
  providedIn: 'root'
})
export class PermissionService extends ServiceParent {

  constructor(private http: HttpClient) {
    super();
  }

  GetList() {
    return this.http.get(`${environment.urlApi}/api/Permisos`)
      .pipe(map(data => {
        return data;
      }));
  }

  Get(query: string, onlyLocalInfo: boolean) {
    return this.http.get(`${environment.urlApi}/api/Permisos/${query}/${onlyLocalInfo}`)
      .pipe(map(data => {
        return data;
      }));
  }

  Update(param: any) {
    return this.http.put(`${environment.urlApi}/api/Permisos/`, param)
      .pipe(map(data => {
        return data;
      }));
  }

  Insert(param: any) {    
    return this.http.post(`${environment.urlApi}/api/Permisos`, param)
      .pipe(map(data => {
        return data;
      }));
  }

}
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookTypesService {

  constructor(private http: HttpClient) { }

  getTypesList() {
    return this.http.get(environment.apiBaseURI + '/bookTypes');
  }
}
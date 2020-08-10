import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

  constructor(private http: HttpClient) { }

  getBooksList() {
    return this.http.get(environment.apiBaseURI + '/books');
  }

  postBook(formData) {
    return this.http.post(environment.apiBaseURI + '/books', formData);
  }

  deleteBook(id) {
    return this.http.delete(environment.apiBaseURI + '/books/' + id);
  }
}
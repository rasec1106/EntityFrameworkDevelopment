import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from '../model/category';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  // dependency injection for httpClient
  constructor(private httpClient: HttpClient) { }

  url = "https://localhost:7046/api/category"
  getCategories(): Observable<Category[]> {
    return this.httpClient.get<Category[]>(this.url)
  }

}

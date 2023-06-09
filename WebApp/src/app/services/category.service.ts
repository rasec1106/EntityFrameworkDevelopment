import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../model/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  // dependency injection for HttpClient
  constructor(private httpClient:HttpClient) { }

  // The url of my backend endpoint
  url = "https://localhost:7046/api/category"

  // This will be the publisher
  getCategories():Observable<Category[]>{
    return this.httpClient.get<Category[]>(this.url)
  }
}

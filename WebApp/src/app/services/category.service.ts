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

  // This will be the publisher
  getCategories():Observable<Category[]>{

  }
}

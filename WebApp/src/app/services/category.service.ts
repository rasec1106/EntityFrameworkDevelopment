import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  // dependency injection for HttpClient
  constructor(private httpClient:HttpClient) { }
}

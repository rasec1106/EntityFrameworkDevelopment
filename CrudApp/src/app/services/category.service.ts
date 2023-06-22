import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from '../model/category';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  currentCategory: Category ={}

  // dependency injection for httpClient
  constructor(private httpClient: HttpClient) { }

  getCategories(): Observable<Category[]> {
    let url = "https://localhost:7046/api/category"
    return this.httpClient.get<Category[]>(url)
  }
  addCategory(category: Category): Observable<Category> {
    let url = "https://localhost:7046/CreateCategory"
    return this.httpClient.post<Category>(url,category)
  }
  updateCategory(category: Category): Observable<Category> {
    let url = "https://localhost:7046/UpdateCategory"
    return this.httpClient.put<Category>(url,category)
  }
  deleteCategory(idCategory: number): Observable<Boolean> {
    let url = `https://localhost:7046/DeleteCategory?id=${idCategory}`
    return this.httpClient.delete<Boolean>(url)
  }

}

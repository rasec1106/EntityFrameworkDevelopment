import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { ProductResponse } from '../model/product-response';
import { Category } from '../model/category';
import { Product } from '../model/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  
  constructor(private httpClient:HttpClient) {
    this.getAllProducts()    
  }
  
  getAllProducts():Observable<any>{
    let url="https://localhost:7144/api/product"
    return this.httpClient.get<ProductResponse>(url).pipe(
      map(res=>res.result)
    );
  }
  getProductsByCategory(category: Category): Observable<any>{
    let url=`https://localhost:7144/getByCategory/${category.categoryCode}`
    return this.httpClient.get<ProductResponse>(url).pipe(
      map(res=>res.result)
    );
  }
}
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { ProductResponse } from '../model/product-response';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  url="localhost:7161/api/ProductContoller"

  constructor(private httpClient:HttpClient) { }
  getProducts():Observable<any>{
    return this.httpClient.get<ProductResponse>(this.url).pipe(
      map(res=>res.result)
    );
  }
}
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Product } from '../_models/Product';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = environment.apiUrl + 'api/';

  constructor(private http: HttpClient) {}

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl + 'Products', httpOptions);
  }

  getProduct(id): Observable<Product> {
    return this.http.get<Product>(this.baseUrl + 'Products/' + id, httpOptions);
  }

  createProduct(product: Product) {
    return this.http.post(this.baseUrl + 'Products/', product, httpOptions);
  }
  updateProduct(id: number, product: Product) {
    return this.http.put(this.baseUrl + 'Products/' + id, product, httpOptions);
  }

  deleteProduct(id): Observable<number> {
    return this.http.delete<number>(this.baseUrl + 'Products/' + id, httpOptions);
  }

}

import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { ProductService } from '../_services/product.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Product } from '../_models/Product';

@Injectable()
export class ProductDetailResolver implements Resolve<Product> {

    constructor(private productService: ProductService, private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Product> {
        return this.productService.getProduct(route.params['id']).pipe(
            catchError( error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/products']);
                return of(null);
        }));
    }
}

import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Product } from '../_models/Product';
import { Injectable } from '@angular/core';
import { ProductService } from '../_services/product.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../_services/auth.service';

@Injectable()
export class ProductEditResolver implements Resolve<Product> {

    constructor(private productsService: ProductService,
        private authService: AuthService ,
        private router: Router,
        private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Product> {
        return this.productsService.getProduct(route.params['id']).pipe(catchError( error => {
            this.alertify.error('Problem retrieving data');
            this.router.navigate(['/products']);
            return of(null);
        }));
    }
}

import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../_services/product.service';
import { Product } from '../../_models/Product';
import { AlertifyService } from '../../_services/alertify.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {
  products: Product[];
  constructor(
    private authService: AuthService,
    private productService: ProductService,
    private alertify: AlertifyService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.route.data.subscribe( data => {
      this.products = data['products'];
    }, error => {
      this.alertify.error(error);
    } );
  }

  deleteProduct(id: number) {
    this.productService.deleteProduct(id).subscribe( data => {
      this.alertify.success('Product deleted successfully');
      this.router.navigate(['/products']);
    }, error => {
      this.alertify.error(error);
    });
  }
   isAdmin() {
     return this.authService.decodedToken.role === 'Admin';
   }
}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../../_models/Product';
import { ProductService } from 'src/app/_services/product.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';


@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  product: Product;

  constructor(
    private authService: AuthService,
    private productService: ProductService,
    private alertify: AlertifyService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.route.data.subscribe( data => {
      this.product = data['product'];
    });

  }

  deleteProduct(id: number) {
    this.productService.deleteProduct(id).subscribe( data => {
      this.alertify.success('Product deleted successfully');
    }, error => {
      this.alertify.error(error);
    }, () =>  this.router.navigate(['/products']));
  }
  
  isAdmin() {
    return this.authService.decodedToken.role === 'Admin';
  }
}

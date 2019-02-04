import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { Product } from '../../_models/Product';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../../_services/alertify.service';
import { NgForm } from '@angular/forms';
import { ProductService } from '../../_services/product.service';
import { AuthService } from '../../_services/auth.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  product: Product;
  @ViewChild('editForm')
  editForm: NgForm;
  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }
  constructor(
    private route: ActivatedRoute,
    private alertify: AlertifyService,
    private productService: ProductService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.product = data['product'];
    });
  }
  updateProduct() {
    this.productService.updateProduct(this.product.id, this.product).subscribe(next => {
      this.alertify.success('Product Updated Successfully');
      this.editForm.reset(this.product);
    }, error => {
      this.alertify.error(error);
    });
  }
}

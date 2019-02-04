import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { Product } from 'src/app/_models/Product';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ProductService } from 'src/app/_services/product.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {
  product: any = { };
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
  ) {

  }

  ngOnInit() {

  }
  createProduct() {
    this.productService.createProduct( this.product).subscribe(next => {
      this.alertify.success('Product Created Successfully');
      this.editForm.reset(this.product);
    }, error => {
      this.alertify.error(error);
    });
  }

}

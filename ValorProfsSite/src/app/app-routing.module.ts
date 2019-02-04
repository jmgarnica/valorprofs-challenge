import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { ProductsListComponent } from './products/products-list/products-list.component';
import { ProductsListResolver } from './_resolvers/products-list.resolver';
import { ProductDetailComponent } from './products/product-detail/product-detail.component';
import { ProductDetailResolver } from './_resolvers/product-detail.resolver';
import { ProductEditComponent } from './products/product-edit/product-edit.component';
import { ProductEditResolver } from './_resolvers/product-edit.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { ProductAddComponent } from './products/product-add/product-add.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  {
     path: '',
     runGuardsAndResolvers: 'always',
     canActivate: [AuthGuard],
     children: [
       { path: 'products', component: ProductsListComponent, resolve: {products: ProductsListResolver} },
       { path: 'products/add', component: ProductAddComponent },
       { path: 'products/:id', component: ProductDetailComponent, resolve: { product: ProductDetailResolver}},
       { path: 'products/edit/:id', component: ProductEditComponent,
       resolve: { product: ProductEditResolver}, canDeactivate: [PreventUnsavedChanges]}
     ]
  },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { ProductEditComponent } from '../products/product-edit/product-edit.component';

@Injectable()
export class PreventUnsavedChanges implements CanDeactivate<ProductEditComponent> {

    canDeactivate(component: ProductEditComponent) {
        if (component.editForm.dirty) {
            return confirm('Are you sure you want to continue? Any unsaved change will be lost');
        }
        return true;
    }
}

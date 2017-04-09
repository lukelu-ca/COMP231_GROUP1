import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, CanDeactivate } from '@angular/router';

import { RecipeEditComponent } from './recipe-edit.component';

@Injectable()
export class RecipeDetailGuard implements CanActivate {

    constructor(private router: Router) {
    }

    canActivate(route: ActivatedRouteSnapshot): boolean {
        let id = +route.url[1].path;
        if (isNaN(id) || id < 1) {
            alert('Invalid product Id');
            // start a new navigation to redirect to list page
            this.router.navigate(['/products']);
            // abort current navigation
            return false;
        };
        return true;
    }
}

@Injectable()
export class RecipeEditGuard implements CanDeactivate<RecipeEditComponent> {

    canDeactivate(component: RecipeEditComponent): boolean {
        if (component.recipeForm.dirty) {
            let productName = component.recipeForm.get('name').value || 'New Product';
            return confirm(`Navigate away and lose all changes to ${name}?`);
        }
        return true;
    }
}
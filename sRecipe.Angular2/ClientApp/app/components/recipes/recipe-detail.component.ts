import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Subscription } from 'rxjs/Subscription';

import { IRecipe } from './recipe';
import { RecipeService } from './recipe.service';

@Component({
    selector: 'recipe-detail',
    template: require('./recipe-detail.component.html')
})

export class RecipeDetailComponent implements OnInit, OnDestroy {
    pageTitle: string = 'Recipe Detail';
    recipe: IRecipe;
    errorMessage: string;
    private sub: Subscription;

    constructor(private route: ActivatedRoute,
        private router: Router,
        private recipeService: RecipeService) {
    }

    ngOnInit(): void {
        this.sub = this.route.params.subscribe(
            params => {
                let id = +params['id'];
                this.getRecipe(id);
            });
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }

    getRecipe(id: number) {
        this.recipeService.getRecipe(id).subscribe(
            recipe => this.recipe = recipe,
            error => this.errorMessage = <any>error);
    }

    onBack(): void {
        this.router.navigate(['/recipes']);
    }

    onRatingClicked(message: string): void {
        this.pageTitle = 'Recipe Detail: ' + message;
    }
}

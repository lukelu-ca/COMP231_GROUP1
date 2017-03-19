import { Component } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { ActivatedRoute, Router } from '@angular/router';
import { RecipeService } from './recipe.service';
import { IRecipe } from './recipe';

@Component({
    templateUrl: 'app/recipes/recipe-detail.component.html'
})

export class RecipeDetailComponent {
    pageTitle: string = 'Recipe Detail!';
    recipe: IRecipe;
    errorMessage: string;
    private sub: Subscription;

    constructor(private route: ActivatedRoute,
        private router: Router,
        private _recipeService: RecipeService) {
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
        this._recipeService.getRecipe(id).subscribe(
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